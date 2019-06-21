using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCX.Helpers;
using BCX.Interfaces;
using BCX.Models;
using BCX.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BCX.Controllers
{
    [Authorize]
    public class EmploymentController : Controller
    {
        private readonly IEmployeeHandler _employeeHandler;
        private readonly IEmployerHandler _employerHandler;
        private readonly ILevelHandler _levelHandler;
        private readonly ITaskHandler _taskHandler;
        public EmploymentController(IEmployeeHandler employeeHandler,ITaskHandler taskHandler,IEmployerHandler employerHandler,ILevelHandler levelHandler  )
        {
            _employeeHandler = employeeHandler;
            _employerHandler = employerHandler;
            _levelHandler = levelHandler;
            _taskHandler = taskHandler;
        }

        public IActionResult Employment( EmploymentViewModel employmentViewModel )
        {
            try
            {
                ViewData["Levels"] = new SelectList(_levelHandler.LevelTypes.Select(u =>
                  new SelectListItem() { Value = u.LevelTypeId.ToString(), Text = $"{u.Description }" }), "Value", "Text");
                return View(employmentViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View( employmentViewModel);
            }

    

        }
        public async Task<IActionResult> UpdateEmployment(int personId)
        {

            ViewData["Levels"] = new SelectList(_levelHandler.LevelTypes.Select(u =>
                 new SelectListItem() { Value = u.LevelTypeId.ToString(), Text = $"{u.Description }" }), "Value", "Text");
            
            try
            {
                var employee = await _employeeHandler.GetEmployeeAsync(personId);
                var _employeeVM = Mapper.Map(new EmploymentViewModel(), employee);
                return View(_employeeVM);
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage = ex.Message;
                return View(new EmploymentViewModel());
            }
       
        }
        public IActionResult Employees()
        {
            ViewData["Levels"] = new SelectList(_levelHandler.LevelTypes.Select(u =>
                 new SelectListItem() { Value = u.LevelTypeId.ToString(), Text = $"{u.Description }" }), "Value", "Text");
            try
            {
                var _employees = _employeeHandler.GetEmployees();
                return View(_employees);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(new EmploymentViewModel());

            }
     
        }



        [HttpPost]
        public async Task<IActionResult> EmployementDetails(EmploymentViewModel employmentViewModel)
        {
            try
            {
                if (employmentViewModel.EmploymentType == "employee")
                    await _employeeHandler.CreateEmployeeAsync(employmentViewModel);
                else
                {
                    var employer = Mapper.Map(new Employer(), employmentViewModel);
                    await _employerHandler.CreateEmployeAsync(employer);
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Employees", "Employment");
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage = ex.Message;
                return View(new EmploymentViewModel());
            }
         
        }
    


        [HttpPost]
        public async Task<IActionResult> UpdateEmployement(EmploymentViewModel employmentViewModel)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if (employmentViewModel.EmploymentType == "employee")
                        await _employeeHandler.UpdateEmployeeAsync(employmentViewModel);

                    return RedirectToAction("Employees", "Employment");
                }
                catch (Exception ex)
                {


                    ViewBag.ErrorMessage = ex.Message;
                    return View(employmentViewModel);
                }
               
            }
            else
                return View();
        }

    }
}
