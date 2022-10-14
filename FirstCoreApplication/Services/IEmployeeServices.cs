using FirstCoreApplication.Models.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApplication.Services
{
    public interface IEmployeeServices
    {
        public List<EmployeeViewModels> GetAllEmployeeList();
        public EmployeeViewModels PrepareCreateModel();
        public int AddNewEmployee(EmployeeViewModels objModel);
        public EmployeeViewModels PrepareEmployeeDetails(int employeeId);
        public EmployeeViewModels EditEmployeeById(int empId);
        public int UpdateEmployeeDetails(EmployeeViewModels objModel);
        public int SoftDeleteEmployee(int empId);
    }
}
