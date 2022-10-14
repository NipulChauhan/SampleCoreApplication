using FirstCoreApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using FirstCoreApplication.Models.View_Models;
using FirstCoreApplication.Models;
using FirstCoreApplication.Services;

namespace FirstCoreApplication.Controllers
{
    public class EmpController : Controller 
    {
        private readonly IEmployeeServices _employeeService;

        public EmpController(IEmployeeServices employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var listModel = _employeeService.GetAllEmployeeList();
            return View(listModel);
        }

        public IActionResult Create()
        {
            EmployeeViewModels model = _employeeService.PrepareCreateModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModels objModel)
        {
            if (ModelState.IsValid && objModel.DepartmentId > 0 && objModel.MobileNumber > 0)
            {
                int nRet = _employeeService.AddNewEmployee(objModel);
                if (nRet > 0)
                {
                    return RedirectToAction("index");
                }
            }
            objModel = _employeeService.PrepareCreateModel();
            return View(objModel);
        }

        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("index");
            }
            EmployeeViewModels objModel = _employeeService.PrepareEmployeeDetails(id);
            return View(objModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null && id == 0)
            {
                return RedirectToAction("index");
            }
            EmployeeViewModels model = _employeeService.EditEmployeeById((int)id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModels objModel)
        {
            if (ModelState.IsValid && objModel.MobileNumber > 0 && objModel.DepartmentId > 0)
            {
                int nRet = _employeeService.UpdateEmployeeDetails(objModel);
            }
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                _employeeService.SoftDeleteEmployee(id);
            }
            return RedirectToAction("index");
        }
    }
}
