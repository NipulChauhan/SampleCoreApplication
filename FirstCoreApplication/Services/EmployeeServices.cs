using FirstCoreApplication.Models;
using FirstCoreApplication.Models.View_Models;
using FirstCoreApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApplication.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeServices(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public List<EmployeeViewModels> GetAllEmployeeList()
        {
            List<EmployeeViewModels> listModel = new List<EmployeeViewModels>();
            var employeeList = _employeeRepo.GetAllEmployees();
            var department = _employeeRepo.GetEmployeeDepartments();

            if (employeeList.Count > 0)
            {
                foreach (var item in employeeList)
                {
                    EmployeeViewModels model = new EmployeeViewModels();
                    model.EmployeeDetailsID = item.EmployeeDetailsID;
                    model.FirstName = item.FirstName;
                    model.LastName = item.LastName;
                    model.MobileNumber = item.MobileNumber;
                    model.Email = item.Email;
                    model.Department = department.Where(x => x.DepartmentID == item.DepartmentId).Select(x => x.DepartmentName).First();
                    listModel.Add(model);
                } 
            }
            return listModel;
        }

        public EmployeeViewModels PrepareCreateModel()
        {
            EmployeeViewModels model = new EmployeeViewModels();
            model.DepartmentList = _employeeRepo.GetEmployeeDepartments();
            model.DepartmentList.Insert(0, new Models.EmployeeDepartment 
                { DepartmentID = 0, DepartmentName = "Select Department" });
            return model;
        }

        public int AddNewEmployee(EmployeeViewModels objModel)
        {
            EmployeeDetails obj = new EmployeeDetails();
            obj.FirstName = objModel.FirstName.Trim();
            obj.LastName = objModel.LastName.Trim();
            obj.Email = objModel.Email.Trim();
            obj.DepartmentId = objModel.DepartmentId;
            obj.MobileNumber = objModel.MobileNumber;
            obj.IsDeleted = false;

            return _employeeRepo.AddEmployee(obj);
        }

        public EmployeeViewModels PrepareEmployeeDetails(int employeeId)
        {
            EmployeeViewModels objModel = new EmployeeViewModels();
            EmployeeDetails objEmp = _employeeRepo.GetEmployeeById(employeeId);
            if (objEmp != null)
            {
                var departmentList = _employeeRepo.GetEmployeeDepartments().ToList();
                if (departmentList.Count > 0)
                {
                    objModel.Department = departmentList.Where(x => x.DepartmentID == objEmp.DepartmentId)
                                        .Select(x => x.DepartmentName).FirstOrDefault();
                }
                objModel.EmployeeDetailsID = objEmp.EmployeeDetailsID;
                objModel.FirstName = objEmp.FirstName;
                objModel.LastName = objEmp.LastName;
                objModel.Email = objEmp.Email;
                objModel.MobileNumber = objEmp.MobileNumber;
            }
            return objModel;
        }

        public EmployeeViewModels EditEmployeeById(int empId)
        {
            EmployeeViewModels model = new EmployeeViewModels();
            model.DepartmentList = _employeeRepo.GetEmployeeDepartments();
            model.DepartmentList.Insert(0, new Models.EmployeeDepartment { DepartmentID = 0
                                , DepartmentName = "Select Department" });
            EmployeeDetails objEmp = _employeeRepo.GetEmployeeById(empId);

            if (model.DepartmentList.Count > 0)
            {
                model.Department = model.DepartmentList.Where(x => x.DepartmentID == objEmp.DepartmentId).Select(x => x.DepartmentName).FirstOrDefault();
            }
            model.EmployeeDetailsID = objEmp.EmployeeDetailsID;
            model.FirstName = objEmp.FirstName;
            model.LastName = objEmp.LastName;
            model.Email = objEmp.Email;
            model.MobileNumber = objEmp.MobileNumber;
            model.DepartmentId = objEmp.DepartmentId;

            return model;
        }

        public int UpdateEmployeeDetails(EmployeeViewModels objModel)
        {
            EmployeeDetails obj = new EmployeeDetails();
            obj.FirstName = objModel.FirstName.Trim();
            obj.LastName = objModel.LastName.Trim();
            obj.Email = objModel.Email.Trim();
            obj.DepartmentId = objModel.DepartmentId;
            obj.MobileNumber = objModel.MobileNumber;
            obj.EmployeeDetailsID = objModel.EmployeeDetailsID;
            obj.IsDeleted = false;

            return _employeeRepo.UpdateEmployee(obj);
        }

        public int SoftDeleteEmployee(int empId)
        {
            return _employeeRepo.RemoveEmployee(empId);
        }


    }
}
