# Employee Management System

An Employee Management System developed using **ASP.NET Core MVC**, **Entity Framework Core**, and **SQL Server**. This project allows users to manage employee records with full CRUD (Create, Read, Update, Delete) functionality and export employee data to Excel.

## 🚀 Features

- Add new employees
- View employee list
- Update employee details
- Delete employee records
- Department and Designation mapping
- Server-side validation
- Export employee data to Excel
- SQL Server database integration using Entity Framework Core

## 🛠️ Technologies Used

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- Razor Views
- HTML5
- CSS3
- Bootstrap
- ClosedXML (Excel Export)

## 📁 Project Structure

```
EmployeeMVC
│
├── Controllers
├── Models
├── Views
├── wwwroot
├── Properties
├── Program.cs
├── appsettings.json
└── EmployeeMVC.csproj
```

## 🗄️ Database

Database: **Company**

Tables Used:
- Employee
- Department_Master
- Designation_Master

## ⚙️ How to Run the Project

1. Clone the repository:

```bash
git clone https://github.com/Thakur-Neetu/EmployeeManagementSystem.git
```

2. Open the project in Visual Studio.

3. Update the connection string in `appsettings.json` to match your local SQL Server instance.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Your SQL Server Connection String"
}
```

4. Restore NuGet packages.

5. Build and run the application.

## 📸 Screenshots

You can add screenshots here later.

Example:

- Employee List
- Add Employee
- Edit Employee
- Export to Excel

## 📚 Learning Outcomes

This project helped me understand:

- ASP.NET Core MVC Architecture
- Entity Framework Core
- CRUD Operations
- SQL Server Integration
- Razor Views
- Dependency Injection
- Model Validation
- LINQ Queries
- Excel Export using ClosedXML

## 🔮 Future Improvements

- User Authentication and Authorization
- Role-Based Access Control
- Search and Filter
- Pagination
- Dashboard
- RESTful Web API Integration
- Logging and Exception Handling

## 👩‍💻 Author

**Neetu Thakur**

GitHub: https://github.com/Thakur-Neetu
