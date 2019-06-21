using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BCX.Models;
using Microsoft.AspNetCore.Authorization;
using BCX.Interfaces;
using BCX.Models.ViewModels;

namespace BCX.Controllers
{
     //[Route("v1/[Controller]")]
  //  [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeHandler _employeeHandler;
        private readonly IEmployerHandler _employerHandler;
        private readonly ILevelHandler _levelHandler;
        private readonly ITaskHandler _taskHandler;
        private readonly IPersonHandler _personHandler;
        public HomeController(IEmployeeHandler employeeHandler,IPersonHandler personHandler, ITaskHandler taskHandler, IEmployerHandler employerHandler, ILevelHandler levelHandler)
        {
            _employeeHandler = employeeHandler;
            _employerHandler = employerHandler;
            _levelHandler = levelHandler;
            _taskHandler = taskHandler;
            _personHandler = personHandler;

        }

        public IActionResult Index( )
        {
            var employees = _employeeHandler.GetEmployees().ToList();
            var levels = _levelHandler.LevelTypes.ToList();
            var tasks = _taskHandler.TaskTypes.ToList();
            var dahsboardVM = new DashboardVIewModel {
                Employees = employees,
                Levels = levels,
                Tasks = tasks
            };
            return View(dahsboardVM);
          
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
