using HamburgerMenuProject.Models;
using HamburgerMenuProject.Models.Entities;
using HamburgerMenuProject.Models.Enums;
using HamburgerMenuProject.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Data;

namespace HamburgerMenuProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DrinkController : Controller
    {
        private readonly IRepository<Drink> drinkrepository;

        public DrinkController(IRepository<Drink> drinkrepository)
        {
            this.drinkrepository = drinkrepository;
        }
        public IActionResult Index()
        {
            var drinkList = drinkrepository.GetAll().ToList();
            return View(drinkList);
        }
       
        public ActionResult Create()
        {
            var enumList = Enum.GetValues(typeof(Size)).Cast<Size>().ToList();
            SelectList selectList = new SelectList(enumList);
            ViewBag.size = selectList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Drink drink, IFormFile formFile)
        {
            drinkrepository.AddPhoto(drink, formFile);
            drinkrepository.Add(drink);
            return RedirectToAction("Index");

        }

        public ActionResult Update(int id)
        {
            var drink = drinkrepository.GetById(id);
            return View(drink);
        }

        [HttpPost]
        public ActionResult Update(Drink drink,IFormFile formFile)
        {
            var Drink = drinkrepository.GetById(drink.ID);
            if (formFile != null)
            {
                drinkrepository.AddPhoto(Drink, formFile);
            }
            Drink.Name = drink.Name;
            Drink.Price = drink.Price;
            Drink.IsActive = drink.IsActive;
            drinkrepository.Update(Drink);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var drink = drinkrepository.GetById(id);
            drinkrepository.Delete(drink);
            return RedirectToAction("Index");
        }
    }
}
