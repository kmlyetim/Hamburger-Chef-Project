using HamburgerMenuProject.Models;
using HamburgerMenuProject.Models.Entities;
using HamburgerMenuProject.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HamburgerMenuProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DessertController : Controller
    {
        private readonly IRepository<Dessert> dessertrepository;

        public DessertController(IRepository<Dessert> dessertrepository)
        {
            this.dessertrepository = dessertrepository;
        }
        public IActionResult Index()
        {
            var dessertList = dessertrepository.GetAll().ToList();
            return View(dessertList);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Dessert dessert, IFormFile formFile)
        {
            dessertrepository.AddPhoto(dessert, formFile);
            dessertrepository.Add(dessert);
            return RedirectToAction("Index");

        }

        public ActionResult Update(int id)
        {
            var dessert = dessertrepository.GetById(id);
            return View(dessert);
        }

        [HttpPost]
        public ActionResult Update(Dessert dessert,IFormFile formFile)
        {
            var Dessert = dessertrepository.GetById(dessert.ID);
            if (formFile !=null)
            {
                
                dessertrepository.AddPhoto(Dessert, formFile);
            }
            Dessert.Name = dessert.Name;
            Dessert.Price = dessert.Price;
            Dessert.IsActive = dessert.IsActive;
            dessertrepository.Update(Dessert);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var dessert = dessertrepository.GetById(id);
            dessertrepository.Delete(dessert);
            return RedirectToAction("Index");
        }
    }
}

