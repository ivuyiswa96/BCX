using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCX.Helpers;
using BCX.Interfaces;
using BCX.Models;
using BCX.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BCX.Controllers
{
  
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> _userManager;
        public SignInManager<ApplicationUser> _signInManager;
        public IPersonHandler _personHandler;
        public AccountController(UserManager<ApplicationUser> userManager,IPersonHandler personHandler, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _personHandler = personHandler;
        }


        

        public IActionResult Login()
        {
            return View();
        }
       // [Authorize]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password,loginViewModel.RememberMe,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.ErrorMessage = "Invalid Login Attempt";
                
                return View(loginViewModel);
            }
            return View(loginViewModel);
        }

        // GET: /<controller>/
        public IActionResult Registration()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
      
        }
        [Authorize]
        public IActionResult UpdatePerson(int personId)
        {

            try
            {
                 var person = Mapper.Map(new RegistrationViewModel(), _personHandler.GetPerson(personId));
                // return RedirectToAction("UpdatePerson", "Account");
                return View(person); 
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(new RegistrationViewModel { PersonId =personId});
           
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel registationViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { Email = registationViewModel.Email, UserName = registationViewModel.Email };
                var result = await _userManager.CreateAsync(user, registationViewModel.Password);
                if (result.Succeeded)
                {

                    var person = Mapper.Map<Person, RegistrationViewModel>(new Person(), registationViewModel);
                    person.UserId = await _userManager.GetUserIdAsync(user);

                    Person _person = await _personHandler.CreatePersonAsnycAsync(person);

                    await _signInManager.SignInAsync(user, false);
                   return RedirectToAction("Employment", "Employment", new EmploymentViewModel() { PersonId = _person.PersonId });
                }
                else
                {

                    foreach (var item in result.Errors)
                    {
                        ViewBag.ErrorMessage = item.Description;
  
                    }
                    return View(registationViewModel);
                }

            }
            else
            {
                ViewBag.ErrorMessage = "Inputs are not valid";
                return View(registationViewModel);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePerson(RegistrationViewModel registationViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var _person = Mapper.Map(new Person(), registationViewModel);
                    var updatedPerson =await _personHandler.UpdatePersonAsnyc(_person);

                    return RedirectToAction("Employees", "Employment");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                    return View(registationViewModel);
                }

            }
            else
            ViewBag.ErrorMessage = "Inputs are not valid";
            return View(registationViewModel);


        }
    }
}
