using HamburgerMenuProject.Context;
using HamburgerMenuProject.Models.User;
using HamburgerMenuProject.Repository.Abstract;
using HamburgerMenuProject.Repository.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Context
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("HamburgerDbStr")));

//Repositories
builder.Services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

// Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    //options.Password.RequiredUniqueChars = 3;
}).AddEntityFrameworkStores<ApplicationDbContext>();

//Filter
builder.Services.AddMvc(options =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    options.Filters.Add(new AuthorizeFilter(policy));
}).AddXmlSerializerFormatters();


//Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "User/UserHome/Index";
        x.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    }
    );

//AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=AdminHome}/{action=Index}/{id?}"
        );

    endpoints.MapAreaControllerRoute(
        name: "User",
        areaName: "User",
        pattern: "User/{controller=UserHome}/{action=Index}/{id?}"
        );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=UserHome}/{action=Index}/{id?}",
        defaults: new { area = "User" }
    );
});

//Seed Data
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    string email = "admin@bilgeadam.com";
    string password = "Deneme123.";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new AppUser()
        {
            UserName = "bilgeadam",
            Email = email,
            FirstName = "Bilge",
            LastName = "Adam",
            Address = "Noramin"
        };
        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "User");
        await userManager.AddToRoleAsync(user, "Admin");
        
    }
}

app.Run();
