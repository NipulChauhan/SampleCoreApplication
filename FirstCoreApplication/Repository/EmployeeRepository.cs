using FirstCoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstCoreApplication.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddEmployee(EmployeeDetails employee)
        {
            _context.EmployeeDetails.Add(employee);
            return _context.SaveChanges();
        }

        public List<EmployeeDetails> GetAllEmployees()
        {
            var records = _context.EmployeeDetails.Where(x => x.IsDeleted == false).ToList();
            return records;
        }

        public EmployeeDetails GetEmployeeById(int employeeId)
        {
            EmployeeDetails objEmp = _context.EmployeeDetails.Where(x => x.IsDeleted == false && x.EmployeeDetailsID == employeeId).FirstOrDefault();
            return objEmp;
        }

        public int RemoveEmployee(int employeeId)
        {
            EmployeeDetails objEmp = _context.EmployeeDetails.Find(employeeId);
            if (objEmp != null)
            {
                objEmp.IsDeleted = true;
                _context.EmployeeDetails.Update(objEmp);
                return _context.SaveChanges();
            }
            return 0;
        }

        public int UpdateEmployee(EmployeeDetails employee)
        {
            var emp = _context.EmployeeDetails.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _context.SaveChanges();
        }

        public List<EmployeeDepartment> GetEmployeeDepartments()
        {
            var department = _context.EmployeeDepartment.ToList();
            return department;
        }

    }
}