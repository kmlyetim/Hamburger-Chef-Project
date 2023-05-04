using HamburgerMenuProject.Models.Entities;
using HamburgerMenuProject.Models.User;
using HamburgerMenuProject.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HamburgerMenuProject.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        private readonly IRepository<Order> ordersRepository;
        private readonly IRepository<Hamburger> hamburgerRepository;
        private readonly IRepository<Drink> drinkRepository;
        private readonly IRepository<Fries> friesRepository;
        private readonly IRepository<Dessert> dessertRepository;
        private readonly IRepository<Sauce> sauceRepository;
        private readonly UserManager<AppUser> userRepository;
        private readonly IOrderRepository orderIncludeRepository;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public AdminHomeController(IRepository<Order> ordersRepository, IRepository<Hamburger> hamburgerRepository, IRepository<Drink> drinkRepository, IRepository<Fries> friesRepository, IRepository<Dessert> dessertRepository, IRepository<Sauce> sauceRepository, UserManager<AppUser> userRepository, IOrderRepository orderIncludeRepository, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.ordersRepository = ordersRepository;
            this.hamburgerRepository = hamburgerRepository;
            this.drinkRepository = drinkRepository;
            this.friesRepository = friesRepository;
            this.dessertRepository = dessertRepository;
            this.sauceRepository = sauceRepository;
            this.userRepository = userRepository;
            this.orderIncludeRepository = orderIncludeRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var users = await userRepository.GetUsersInRoleAsync("User");
            ViewBag.UsersCount = users.Count();      
            ViewBag.OrdersCount = ordersRepository.GetAll().ToList().Count();
            ViewBag.UserList = users.ToList();
            ViewBag.OrderList = orderIncludeRepository.GetAllOrdersInludeProduct();
            return View();
        }
        public async Task<IActionResult> GetUser()
        {
            var userList = await userRepository.GetUsersInRoleAsync("User");
            List<AppUser> users = new List<AppUser>();
            users.AddRange(userList);
            return PartialView("_GetUsersPartial", users);
        }
        public IActionResult GetOrder()
        {
            var orderList = orderIncludeRepository.GetAllOrdersInludeProduct();
            return PartialView("_GetOrdersPartial", orderList);
        }


        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "UserHome", new { Area = "User" });
        }
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userRepository.FindByIdAsync(id);
            await userManager.DeleteAsync(user);
            return RedirectToAction("Index", "AdminHome", new { Area = "Admin" });
        }
    }
}
