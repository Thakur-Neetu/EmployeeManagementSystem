using Microsoft.EntityFrameworkCore;

namespace EmployeeMVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Department> Department_Master { get; set; }

        public DbSet<Designation> Designation_Master { get; set; }
    }
}