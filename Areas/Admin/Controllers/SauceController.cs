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
    public class SauceController : Controller
    {
        private readonly IRepository<Sauce> sauceRepository;

        public SauceController(IRepository<Sauce> sauceRepository)
        {
            this.sauceRepository = sauceRepository;
        }
        public IActionResult Index()
        {
            var sauceList = sauceRepository.GetAll().ToList();
            return View(sauceList);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Sauce sauce, IFormFile formFile)
        {
            sauceRepository.AddPhoto(sauce, formFile);
            sauceRepository.Add(sauce);
            return RedirectToAction("Index");

        }

        public ActionResult Update(int id)
        {
            var sauce = sauceRepository.GetById(id);
            return View(sauce);
        }

        [HttpPost]
        public ActionResult Update(Sauce sauce,IFormFile formFile)
        {
            var Sauce = sauceRepository.GetById(sauce.ID);
            if (formFile !=null)
            {
                sauceRepository.AddPhoto(Sauce, formFile);
            }
            Sauce.Name = sauce.Name;
            Sauce.Price = sauce.Price;
            Sauce.IsActive = sauce.IsActive;
            sauceRepository.Update(Sauce);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var sauce = sauceRepository.GetById(id);
            sauceRepository.Delete(sauce);
            return RedirectToAction("Index");
        }
    }
}

