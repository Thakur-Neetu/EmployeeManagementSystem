using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeMVC.Models
{
    [Table("Designation_Master")]
    public class Designation
    {
        [Key]
        public int Designation_Id { get; set; }

        public string? Designation_Name { get; set; }
    }
}