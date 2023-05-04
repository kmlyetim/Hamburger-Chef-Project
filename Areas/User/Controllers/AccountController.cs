using AutoMapper;
using HamburgerMenuProject.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Security.Claims;

namespace HamburgerMenuProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly Microsoft.AspNetCore.Identity.IPasswordHasher<AppUser> passwordHasher;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(IMapper mapper, UserManager<AppUser> userManager, IPasswordHasher<AppUser> passwordHasher, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM userVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = mapper.Map<AppUser>(userVM);
                //AppUser user = new();
                //mapper.Map(userVM, user);
                IdentityResult result = await userManager.CreateAsync(user, userVM.Password);
                
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction("Index", "UserHome", new {area = "User"});
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("User Create", $"{error.Code} - {error.Description}");
                    }
                }
            }
            return View(userVM);
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM login)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByEmailAsync(login.Email);
                if (appUser != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(appUser, login.Password, false, false);
                    if (result.Succeeded)
                    {
                        var userRoles = await userManager.GetRolesAsync(appUser);
                        var authClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,appUser.Email)
                        };

                        foreach (var userRole in userRoles)
                        {
                            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                        }

                        return RedirectToAction("Index", "UserHome", new { Area = "User" });
                        //if (userRoles.Contains("Admin"))
                        //{
                        //    return RedirectToAction("Index", "AdminHome", new {Area = "Admin"});
                        //}
                        //else
                        //{
                        //    return RedirectToAction("Index", "UserHome", new { Area = "User" });
                        //}
                    }
                }
                ModelState.AddModelError("User Operation", $"Kullanıcı girişi başarısız olmuştur. Böyle bir maile {login.Email} sahip kullanıcı bulunamadı");

            }
            return View(login);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "UserHome", new { Area = "User" });
        }
    }
}
