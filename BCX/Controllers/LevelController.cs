using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCX.Interfaces;
using BCX.Models;
using BCX.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BCX.Controllers
{
    public class LevelController : Controller
    {


        private readonly ILevelHandler _levelHandler;
        private readonly ITaskHandler _taskHandler;
        public LevelController(ITaskHandler taskHandler, ILevelHandler levelHandler)
        {

            _levelHandler = levelHandler;
            _taskHandler = taskHandler;
        }


        public IActionResult RemoveLevel(int levelId)
        {
            try
            {
                _levelHandler.RemoveLevelAsync(levelId);
                return RedirectToAction("Levels", "Level");
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Levels", "Level");
            }
         
        }

       
        public IActionResult Levels()
        {
            try
            {
                var levels = _levelHandler.LevelTypes;
                return View(levels);
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Levels", "Level");
            }
         
        }



        public IActionResult LevelModal()
        {
            return PartialView("_LevelPartial",new LevelType());
        }

        public async Task<IActionResult> UpdateLevel(int levelId)
        {
            var level = await _levelHandler.GetLevel(levelId);
            return PartialView("_UpdatePartial",level);
        }

        [HttpPost]
        public IActionResult UpdateLevel(LevelType levelType )
        {
            try
            {
                var _level =  _levelHandler.UpdateLevelAsync(levelType);
                return RedirectToAction("Levels", "Level");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Levels", "Level");
            }
        
        }


        [HttpPost]
        public async Task< IActionResult> CreateLevel(LevelType level)
        {

            ViewData["Levels"] = new SelectList(_levelHandler.LevelTypes.Select(u =>
                    new SelectListItem() { Value = u.LevelTypeId.ToString(), Text = $"{u.Description }" }), "Value", "Text");
            var _level = await _levelHandler.CreateLevelAsync(level);
            return RedirectToAction("Levels","Level");
        }




    }
}
