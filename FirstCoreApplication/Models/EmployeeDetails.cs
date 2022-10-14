using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FirstCoreApplication.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int EmployeeDetailsID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        public int MobileNumber { get; set; }

        public int DepartmentId { get; set; }

        public bool IsDeleted { get; set; }

        //public List<EmployeeDepartment> Departments { get; set; }
    }
}
