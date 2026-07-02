using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMVC.Models
{
    [Table("Department_Master")]
    public class Department
    {
        [Key]
        public int Department_Id { get; set; }

        public string? Department_Name { get; set; }
    }
}