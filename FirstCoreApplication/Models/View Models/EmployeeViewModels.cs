using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApplication.Models.View_Models
{
    public class EmployeeViewModels
    {
        [Key]
        public int EmployeeDetailsID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        public int MobileNumber { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department is required.")]
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public bool IsDeleted { get; set; }
        public IList<EmployeeDepartment> DepartmentList { get; set; }
    }
}
