using FirstCoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApplication.Repository
{
    public interface IEmployeeRepository
    {
        public int AddEmployee(EmployeeDetails employee);
        public List<EmployeeDetails> GetAllEmployees();
        public EmployeeDetails GetEmployeeById(int employeeId);
        public int UpdateEmployee(EmployeeDetails employee);
        public int RemoveEmployee(int employeeId);

        public List<EmployeeDepartment> GetEmployeeDepartments();
    }
}
