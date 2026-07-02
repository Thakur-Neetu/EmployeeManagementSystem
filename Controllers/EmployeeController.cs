using ClosedXML.Excel;
using EmployeeMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // ===========================
        // Display Employee List
        // ===========================
        [HttpGet]
        public IActionResult Index()
        {
            var employees = (from e in _context.Employee
                             join d in _context.Department_Master
                             on e.EMP_DEPARTMENT_ID equals d.Department_Id

                             join des in _context.Designation_Master
                             on e.EMP_DESIGNATION_ID equals des.Designation_Id

                             select new EmployeeListViewModel
                             {
                                 EMP_ID = e.EMP_ID,
                                 EMP_NAME = e.EMP_NAME,
                                 EMP_MOBILE = e.EMP_MOBILE,
                                 EMP_EMAIL = e.EMP_EMAIL,

                                 Department_Name = d.Department_Name,
                                 Designation_Name = des.Designation_Name
                             }).ToList();

            return View(employees);
        }

        // ===========================
        // Display Create Form
        // ===========================
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(
                _context.Department_Master.ToList(),
                "Department_Id",
                "Department_Name");

            ViewBag.Designations = new SelectList(
                _context.Designation_Master.ToList(),
                "Designation_Id",
                "Designation_Name");

            return View();
        }

        // ===========================
        // Save Employee
        // ===========================
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = new SelectList(
                    _context.Department_Master.ToList(),
                    "Department_Id",
                    "Department_Name");

                ViewBag.Designations = new SelectList(
                    _context.Designation_Master.ToList(),
                    "Designation_Id",
                    "Designation_Name");

                return View(employee);
            }

            employee.CREATED_ON = DateTime.Now;
            employee.CREATED_BY = "Admin";

            _context.Employee.Add(employee);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // ===========================
        // Export Employee List to Excel
        // ===========================
        [HttpGet]
        public IActionResult ExportToExcel()
        {
            var employees = (from e in _context.Employee

                             join d in _context.Department_Master
                             on e.EMP_DEPARTMENT_ID equals d.Department_Id

                             join des in _context.Designation_Master
                             on e.EMP_DESIGNATION_ID equals des.Designation_Id

                             select new EmployeeListViewModel
                             {
                                 EMP_ID = e.EMP_ID,
                                 EMP_NAME = e.EMP_NAME,
                                 EMP_MOBILE = e.EMP_MOBILE,
                                 EMP_EMAIL = e.EMP_EMAIL,
                                 Department_Name = d.Department_Name,
                                 Designation_Name = des.Designation_Name
                             }).ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Employees");

                // Header Row
                worksheet.Cell(1, 1).Value = "Employee ID";
                worksheet.Cell(1, 2).Value = "Employee Name";
                worksheet.Cell(1, 3).Value = "Mobile";
                worksheet.Cell(1, 4).Value = "Email";
                worksheet.Cell(1, 5).Value = "Department ID";
                worksheet.Cell(1, 6).Value = "Designation ID";

                int row = 2;

                foreach (var emp in employees)
                {
                    worksheet.Cell(row, 1).Value = emp.EMP_ID;
                    worksheet.Cell(row, 2).Value = emp.EMP_NAME;
                    worksheet.Cell(row, 3).Value = emp.EMP_MOBILE;
                    worksheet.Cell(row, 4).Value = emp.EMP_EMAIL;
                    worksheet.Cell(row, 5).Value = emp.Department_Name;
                    worksheet.Cell(row, 6).Value = emp.Designation_Name;

                    row++;
                }

                // Auto-fit columns
                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);

                    return File(
                        stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Employees.xlsx");
                }
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _context.Employee.FirstOrDefault(e => e.EMP_ID == id);

            if (employee == null)
            {
                return NotFound();
            }

            ViewBag.Departments = new SelectList(
                _context.Department_Master.ToList(),
                "Department_Id",
                "Department_Name",
                employee.EMP_DEPARTMENT_ID);

            ViewBag.Designations = new SelectList(
                _context.Designation_Master.ToList(),
                "Designation_Id",
                "Designation_Name",
                employee.EMP_DESIGNATION_ID);

            return View(employee);
        }


        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = new SelectList(
                    _context.Department_Master.ToList(),
                    "Department_Id",
                    "Department_Name",
                    employee.EMP_DEPARTMENT_ID);

                ViewBag.Designations = new SelectList(
                    _context.Designation_Master.ToList(),
                    "Designation_Id",
                    "Designation_Name",
                    employee.EMP_DESIGNATION_ID);

                return View(employee);
            }

            var existingEmployee = _context.Employee.FirstOrDefault(e => e.EMP_ID == employee.EMP_ID);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.EMP_NAME = employee.EMP_NAME;
            existingEmployee.EMP_MOBILE = employee.EMP_MOBILE;
            existingEmployee.EMP_EMAIL = employee.EMP_EMAIL;
            existingEmployee.EMP_DEPARTMENT_ID = employee.EMP_DEPARTMENT_ID;
            existingEmployee.EMP_DESIGNATION_ID = employee.EMP_DESIGNATION_ID;

            existingEmployee.UPDATED_ON = DateTime.Now;
            existingEmployee.UPDATED_BY = "Admin";

            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employee.FirstOrDefault(e => e.EMP_ID == id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}