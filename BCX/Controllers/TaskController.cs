using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCX.Interfaces;
using BCX.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BCX.Controllers
{
 //   [Authorize]
    public class TaskController : Controller
    {
        private readonly ILevelHandler _levelHandler;
        private readonly ITaskHandler _taskHandler;
        public TaskController( ITaskHandler taskHandler, ILevelHandler levelHandler)
        {
            
            _levelHandler = levelHandler;
            _taskHandler = taskHandler;
        }

        [HttpGet]
        public IActionResult GetTaskModal(int employeeId )
        {
     
            return PartialView("_TaskPartial",new EmploymentViewModel {EmployeeId  =employeeId } );
        }

        [HttpGet]
        public IActionResult GetTaskById(int taskId )
        {
            var task =  _taskHandler.GetTaskById(taskId);
            var empVM = new EmploymentViewModel {
                EmployeeId = task.EmployeeId,
                LevelTypeId = task.TaskTypeId,
                HourWorked = task.Duration.Hours,
                Description = task.Description,
                RatePerHour = task.RatePerHour,
                TaskTypeId = task.TaskTypeId

            
            };
            return PartialView("_UpdateTaskPartial",empVM );
        }


        [HttpGet]
        public IActionResult Tasks(int employeeId)
        {

            try
            {
                
                var _tasks = _taskHandler.GetTaskByEmpId(employeeId);
                if (_tasks == null)
                {
                    ViewBag.ErrorMessage = "This Employee have no taks assigned to his name";
                    return View();
                }
                return View(_tasks);
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        
        }



        [HttpPost]
        public async Task<IActionResult> AddTask(EmploymentViewModel employmentViewModel)
        {
            try
            {
                var results = await _taskHandler.CreateTaskAsnyc(employmentViewModel);

                return RedirectToAction("Tasks", "Task", new EmploymentViewModel { EmployeeId = results.EmployeeId });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Tasks", "Task", new EmploymentViewModel ());
            }
    
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTask(EmploymentViewModel employmentViewModel)
        {
            try
            {
                var results = await _taskHandler.UpdateTaskAsnyc(employmentViewModel);

                return RedirectToAction("Tasks", "Task", new EmploymentViewModel { EmployeeId = results.EmployeeId });
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Tasks", "Task", new EmploymentViewModel());
            }
      
        }

        
        public async Task<IActionResult> RemoveTask(int taskTypeId)
        {
           var results =  await _taskHandler.RemoveTaskAsnyc(taskTypeId);

            return RedirectToAction("Tasks", "Task", new EmploymentViewModel {EmployeeId = results.EmployeeId });
        }
    }

}
