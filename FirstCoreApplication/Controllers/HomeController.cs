using FirstCoreApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FirstCoreApplication.Repository;

namespace FirstCoreApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepo;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepo)
        {
            _logger = logger;
            _employeeRepo = employeeRepo;
        }

        public IActionResult Index()
        {
            var checkEmp = _employeeRepo.GetAllEmployees();
            var testData = _employeeRepo.GetEmployeeDepartments();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Employee()
        {
            return View();
        }

        public IActionResult Department()
        { 
            //FirstCoreApplication.Models.View_Models.DepartmentViewModel  model = new Models.View_Models.DepartmentViewModel();
            //model.EmployeeDepartment = _employeeRepo.GetEmployeeDepartments();
            return View(_employeeRepo.GetEmployeeDepartments());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
