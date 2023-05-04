using HamburgerMenuProject.Models;
using HamburgerMenuProject.Models.Entities;
using HamburgerMenuProject.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerMenuProject.Controllers
{
    [Authorize(Roles ="Admin")]
    public class HamburgerController : Controller
    {
        private readonly IRepository<Hamburger> hamburgerRepository;

        public HamburgerController(IRepository<Hamburger> hamburgerRepository)
        {
            this.hamburgerRepository = hamburgerRepository;
        }
        public ActionResult Index()
        {
            var hamburgerList = hamburgerRepository.GetAll().ToList();
            return View(hamburgerList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Hamburger hamburger,IFormFile formFile)
        {
            hamburgerRepository.AddPhoto(hamburger, formFile);
            hamburgerRepository.Add(hamburger);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var hamburger = hamburgerRepository.GetById(id);
            return View(hamburger);
        }

        [HttpPost]        
        public ActionResult Update(Hamburger hamburger, IFormFile formFile)
        {
            var Hamburger = hamburgerRepository.GetById(hamburger.ID);
            if (formFile != null)
            {
                hamburgerRepository.AddPhoto(Hamburger, formFile);
            }
            Hamburger.Name = hamburger.Name;
            Hamburger.Price = hamburger.Price;
            Hamburger.IsActive = hamburger.IsActive;
            hamburgerRepository.Update(Hamburger);
            return RedirectToAction("Index");
        }

              
        public ActionResult Delete(int id)
        {
            var hamburger = hamburgerRepository.GetById(id);
            hamburgerRepository.Delete(hamburger);
            return RedirectToAction("Index");
        }
    }
}
