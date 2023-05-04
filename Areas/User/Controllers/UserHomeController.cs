using HamburgerMenuProject.Models;
using HamburgerMenuProject.Models.BaseEntities;
using HamburgerMenuProject.Models.Entities;
using HamburgerMenuProject.Models.User;
using HamburgerMenuProject.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections;
using System.Diagnostics;
using System.Xml.Linq;

namespace HamburgerMenuProject.Controllers
{
    public class UserHomeController : Controller
    {
        private readonly ILogger<UserHomeController> _logger;
        private readonly IRepository<Hamburger> hamburgerRepository;
        private readonly IRepository<Fries> friesRepository;
        private readonly IRepository<Dessert> dessertRepository;
        private readonly IRepository<Drink> drinkRepository;
        private readonly IRepository<Sauce> sauceRepository;
        private readonly IRepository<Menu> menuRepository;
        private readonly IRepository<Order> orderRepository;
        private readonly UserManager<AppUser> userManager;
        private readonly IOrderRepository orderRepo;

        public UserHomeController(ILogger<UserHomeController> logger, IRepository<Hamburger> hamburgerRepository, IRepository<Fries> friesRepository, IRepository<Dessert> dessertRepository, IRepository<Drink> drinkRepository, IRepository<Sauce> sauceRepository, IRepository<Menu> menuRepository, IRepository<Order> orderRepository, UserManager<AppUser> userManager, IOrderRepository orderRepo)
        {
            _logger = logger;
            this.hamburgerRepository = hamburgerRepository;
            this.friesRepository = friesRepository;
            this.dessertRepository = dessertRepository;
            this.drinkRepository = drinkRepository;
            this.sauceRepository = sauceRepository;
            this.menuRepository = menuRepository;
            this.orderRepository = orderRepository;
            this.userManager = userManager;
            this.orderRepo = orderRepo;
        }

        public static Order order = new();
        [AllowAnonymous]
        public IActionResult Index()
        {            
            int count = 0;
            foreach (var item in order.Hamburgers)
            {
                count += item.Piece;
            }
            foreach (var item in order.Fries)
            {
                count += item.Piece;

            }
            foreach (var item in order.Desserts)
            {
                count += item.Piece;

            }
            foreach (var item in order.Menus)
            {                
                count += item.Piece;

            }
            foreach (var item in order.Sauces)
            {                
                count += item.Piece;

            }
            foreach (var item in order.Drinks)
            {                
                count += item.Piece;

            }
            ViewBag.ItemCount = count;
            return View();
        }
        [AllowAnonymous]
        public IActionResult Menus()
        {
            var hamburgerList = hamburgerRepository.GetAll().ToList();
            var dessertList = dessertRepository.GetAll().ToList();
            var drinkList = drinkRepository.GetAll().ToList();
            var friesList = friesRepository.GetAll().ToList();
            var sauceList = sauceRepository.GetAll().ToList();
            var menuList = menuRepository.GetAll().ToList();
            FoodListVM foodListVM = new();
            foodListVM.Hamburgers = hamburgerList;
            foodListVM.Desserts = dessertList;
            foodListVM.Drinks = drinkList;
            foodListVM.Fries = friesList;
            foodListVM.Sauces = sauceList;
            foodListVM.Menus = menuList;
            int count = 0;
            foreach (var item in order.Hamburgers)
            {
                count += item.Piece;
            }
            foreach (var item in order.Fries)
            {
                count += item.Piece;

            }
            foreach (var item in order.Desserts)
            {
                count += item.Piece;

            }
            foreach (var item in order.Menus)
            {
                count += item.Piece;

            }
            foreach (var item in order.Sauces)
            {
                count += item.Piece;

            }
            foreach (var item in order.Drinks)
            {
                count += item.Piece;

            }
            ViewBag.ItemCount = count;
            return View(foodListVM);
        }
        [AllowAnonymous]
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult UserLogin()
        {
            return View();
        }
        public IActionResult SendMessage()
        {
            return PartialView("_SendMessage");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        
        public async Task<IActionResult> SaveOrder()
        {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            Order saveOrder = new();
            saveOrder.UserId = user.Id;
            order.UserId = user.Id;
            orderRepository.Add(saveOrder);
            order.ID = saveOrder.ID;
            saveOrder = order;
            orderRepo.UpdateMethod(saveOrder);            
            
            
            order.Menus.Clear();
            order.Hamburgers.Clear();
            order.Drinks.Clear();
            order.Desserts.Clear();
            order.Fries.Clear();
            order.Sauces.Clear();
            return RedirectToAction("Menus");
        }

        public IActionResult ShoppingCart()
        {
            if (order != null)
            {
                decimal total = 0;
                int count = 0;
                foreach (var item in order.Hamburgers)
                {
                    total += (decimal)item.Price * item.Piece;
                    count += item.Piece;
                }
                foreach (var item in order.Fries)
                {
                    total += (decimal)item.Price * item.Piece;
                    count += item.Piece;

                }
                foreach (var item in order.Desserts)
                {
                    total += (decimal)item.Price * item.Piece;
                    count += item.Piece;

                }
                foreach (var item in order.Menus)
                {
                    total += (decimal)item.Price * item.Piece;
                    count += item.Piece;

                }
                foreach (var item in order.Sauces)
                {
                    total += (decimal)item.Price * item.Piece;
                    count += item.Piece;

                }
                foreach (var item in order.Drinks)
                {
                    total += (decimal)item.Price * item.Piece;
                    count += item.Piece;

                }
                ViewBag.TotalPrice = total;
                ViewBag.ItemCount = count;
                order.Price=total;
            }
            
            return View(order);
        }

        public IActionResult AddShoppingCart(int id,string name)
        {
            switch (name)
            {
                case "hamburger":
                    var hamburger = hamburgerRepository.GetById(id);
                    var forHamList = order.Hamburgers.Where(x => x.ID == id).FirstOrDefault();                    
                    if (order.Hamburgers.Contains(forHamList))
                    {
                        forHamList.Piece++;
                        decimal defHamPrice = (decimal)hamburgerRepository.GetById(id).Price;
                        hamburger.Price = defHamPrice*hamburger.Piece;
                    }
                    else
                    {
                        order.Hamburgers.Add(hamburger);
                    }                    
                    break;

                case "fries":
                    var fries = friesRepository.GetById(id);
                    var forFriesList = order.Fries.Where(x => x.ID == id).FirstOrDefault();
                    if (order.Fries.Contains(forFriesList))
                    {
                        forFriesList.Piece++;
                        decimal defFriesPrice = (decimal)friesRepository.GetById(id).Price;
                        fries.Price = defFriesPrice*fries.Piece;
                    }
                    else
                    {
                        order.Fries.Add(fries);
                    }                    
                    break;

                case "drink":
                    var drink = drinkRepository.GetById(id);
                    var forDrinkList = order.Drinks.Where(x => x.ID == id).FirstOrDefault();
                    if (order.Drinks.Contains(forDrinkList))
                    {
                        forDrinkList.Piece++;
                        decimal defDrinkPrice = (decimal)drinkRepository.GetById(id).Price;
                        drink.Price = defDrinkPrice * drink.Piece;
                    }
                    else
                    {
                        order.Drinks.Add(drink);
                    }
                    break;

                case "dessert":
                    var dessert = dessertRepository.GetById(id);
                    var forDessertList = order.Desserts.Where(x => x.ID == id).FirstOrDefault();
                    if (order.Desserts.Contains(forDessertList))
                    {
                        forDessertList.Piece++;
                        decimal defDessertPrice = (decimal)dessertRepository.GetById(id).Price;
                        dessert.Price = defDessertPrice * dessert.Piece;
                    }
                    else
                    {
                        order.Desserts.Add(dessert);
                    }
                    break;

                case "sauce":
                    var sauce = sauceRepository.GetById(id);
                    var forSauceList = order.Sauces.Where(x => x.ID == id).FirstOrDefault();
                    if (order.Sauces.Contains(forSauceList))
                    {
                        forSauceList.Piece++;
                        decimal defSaucePrice = (decimal)sauceRepository.GetById(id).Price;
                        sauce.Price = defSaucePrice * sauce.Piece;
                    }
                    else
                    {
                        order.Sauces.Add(sauce);
                    }
                    break;

                case "menu":
                    var menu = menuRepository.GetById(id);
                    var forMenuList = order.Menus.Where(x => x.ID == id).FirstOrDefault();
                    if (order.Menus.Contains(forMenuList))
                    {
                        forMenuList.Piece++;
                        decimal defMenuPrice = (decimal)menuRepository.GetById(id).Price;
                        menu.Price = defMenuPrice * menu.Piece;
                    }
                    else
                    {
                        order.Menus.Add(menu);
                    }
                    break;
            }
            return RedirectToAction("Menus");
        }

        public IActionResult DeleteOrderItem(int id, string name)
        {
            switch (name)
            {
                case "hamburger":
                    var hamburger = order.Hamburgers.Where(x => x.ID == id).FirstOrDefault();
                    order.Hamburgers.Remove(hamburger);
                    break;

                case "fries":
                    var fries = order.Fries.Where(x => x.ID == id).FirstOrDefault();
                    order.Fries.Remove(fries);
                    break;

                case "drink":
                    var drink = order.Drinks.Where(x => x.ID == id).FirstOrDefault();
                    order.Drinks.Remove(drink);
                    break;

                case "dessert":                    
                    var dessert = order.Desserts.Where(x=> x.ID==id).FirstOrDefault();
                    order.Desserts.Remove(dessert);
                    break;

                case "sauce":
                    var sauce = order.Sauces.Where(x => x.ID == id).FirstOrDefault();
                    order.Sauces.Remove(sauce);
                    break; ;

                case "menu":
                    var menu = order.Menus.Where(x => x.ID == id).FirstOrDefault();
                    order.Menus.Remove(menu);                    
                    break;
            }
            return RedirectToAction("ShoppingCart");
        }
        public IActionResult Increase(int id, string name)
        {
            switch (name)
            {
                case "hamburger":                    
                    var hamburger = order.Hamburgers.Where(x => x.ID == id).FirstOrDefault();
                    hamburger.Piece++;                    
                    break;

                case "fries":
                    var fries = order.Fries.Where(x => x.ID == id).FirstOrDefault();
                    fries.Piece++;
                    break;

                case "drink":
                    var drink = order.Drinks.Where(x => x.ID == id).FirstOrDefault();
                    drink.Piece++;
                    break;

                case "dessert":
                    var dessert = order.Desserts.Where(x => x.ID == id).FirstOrDefault();
                    dessert.Piece++;
                    break;

                case "sauce":
                    var sauce = order.Sauces.Where(x => x.ID == id).FirstOrDefault();
                    sauce.Piece++;
                    break; ;

                case "menu":
                    var menu = order.Menus.Where(x => x.ID == id).FirstOrDefault();
                    menu.Piece++;
                    break;
            }
            return RedirectToAction("ShoppingCart");
        }
        public IActionResult Decrease(int id, string name)
        {
            switch (name)
            {
                case "hamburger":
                    var hamburger = order.Hamburgers.Where(x => x.ID == id).FirstOrDefault();
                    if (hamburger.Piece>1)
                    {
                        hamburger.Piece--;                        
                    }
                    break;

                case "fries":
                    var fries = order.Fries.Where(x => x.ID == id).FirstOrDefault();
                    if (fries.Piece>1)
                    {
                        fries.Piece--;

                    }
                    break;

                case "drink":
                    var drink = order.Drinks.Where(x => x.ID == id).FirstOrDefault();
                    if (drink.Piece>1)
                    {
                        drink.Piece--;
                    }
                    break;

                case "dessert":
                    var dessert = order.Desserts.Where(x => x.ID == id).FirstOrDefault();
                    if (dessert.Piece>1)
                    {
                        dessert.Piece--;
                    }
                    break;

                case "sauce":
                    var sauce = order.Sauces.Where(x => x.ID == id).FirstOrDefault();
                    if (sauce.Piece>1)
                    {
                        sauce.Piece--;
                    }
                    break; ;

                case "menu":
                    var menu = order.Menus.Where(x => x.ID == id).FirstOrDefault();
                    if (menu.Piece>1)
                    {
                        menu.Piece--;
                    }
                    break;
            }
            return RedirectToAction("ShoppingCart");
        }

    }


}