
using System.ComponentModel.DataAnnotations;

namespace FirstCoreApplication.Models
{
    public class EmployeeDepartment
    {
        [Key]
        public int DepartmentID { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
