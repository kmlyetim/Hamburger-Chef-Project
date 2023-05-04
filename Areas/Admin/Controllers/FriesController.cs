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
    public class FriesController : Controller
    {
        private readonly IRepository<Fries> friesRepository;

        public FriesController(IRepository<Fries> friesRepository)
        {
            this.friesRepository = friesRepository;
        }
        public IActionResult Index()
        {
            var friesList = friesRepository.GetAll().ToList();
            return View(friesList);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Fries fries,IFormFile formFile)
        {
            friesRepository.AddPhoto(fries, formFile);
            friesRepository.Add(fries);
            return RedirectToAction("Index");

        }
        public ActionResult Update(int id)
        {
            var fries = friesRepository.GetById(id);
            return View(fries);
        }

        [HttpPost]
        public ActionResult Update(Fries fries,IFormFile formFile)
        {
            var Fries = friesRepository.GetById(fries.ID);
            if (formFile != null)
            {
                friesRepository.AddPhoto(Fries, formFile);
            }
            Fries.Name = fries.Name;
            Fries.Price = fries.Price;
            Fries.IsActive = fries.IsActive;
            friesRepository.Update(Fries);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var fries = friesRepository.GetById(id);
            friesRepository.Delete(fries);
            return RedirectToAction("Index");
        }
    }
}
