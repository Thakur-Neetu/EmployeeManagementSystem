using System.ComponentModel.DataAnnotations;

namespace EmployeeMVC.Models
{
    public class Employee
    {
        [Key]
        public int? EMP_ID { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        public string? EMP_NAME { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Mobile Number must be exactly 10 digits")]
        public string? EMP_MOBILE { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid Email Address")]
        public string? EMP_EMAIL { get; set; }

        [Required(ErrorMessage = "Please select Department")]
        public int? EMP_DEPARTMENT_ID { get; set; }

        [Required(ErrorMessage = "Please select Designation")]
        public int? EMP_DESIGNATION_ID { get; set; }

        public DateTime CREATED_ON { get; set; }

        public string? CREATED_BY { get; set; }

        public DateTime? UPDATED_ON { get; set; }

        public string? UPDATED_BY { get; set; }
    }
}