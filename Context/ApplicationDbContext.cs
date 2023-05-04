using HamburgerMenuProject.Models.Entities;
using HamburgerMenuProject.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HamburgerMenuProject.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //Hamburgers
            builder.Entity<Hamburger>().HasData(
                    new Hamburger
                    {
                        ID = 1,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Whopper",
                        Price = 32,
                        Photo = "Whopper.png",
                        Piece = 1
                    },
                    new Hamburger
                    {
                        ID = 2,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Double Whopper",
                        Price = 45,
                        Photo = "DoubleWhopper.png",
                        Piece = 1
                    },
                    new Hamburger
                    {
                        ID = 3,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Texas Smokehouse",
                        Price = 37,
                        Photo = "TexasSmokeHouse.png",
                        Piece = 1
                    },
                    new Hamburger
                    {
                        ID = 4,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Cheese Burger",
                        Price = 29,
                        Photo = "Cheeseburger.png",
                        Piece = 1
                    },
                    new Hamburger
                    {
                        ID = 5,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Chicken Royale",
                        Price = 34,
                        Photo = "ChickenRoyale.png",
                        Piece = 1
                    },
                    new Hamburger
                    {
                        ID = 6,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Steakhouse",
                        Price = 41,
                        Photo = "SteakHouse.png",
                        Piece = 1
                    }
                );


            //Drinks
            builder.Entity<Drink>().HasData(
                    new Drink
                    {
                        ID = 1,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Fuse Tea",
                        Price = 4,
                        Photo = "FuseTea.png",
                        Piece = 1
                    },
                    new Drink
                    {
                        ID = 2,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Coca-Cola",
                        Price = 5,
                        Photo = "CocaCola.png",
                        Piece = 1
                    },
                    new Drink
                    {
                        ID = 3,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Coca-Cola Zero",
                        Price = 5,
                        Photo = "CocaColaZero.png",
                        Piece = 1
                    },
                    new Drink
                    {
                        ID = 4,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Fanta",
                        Price = 5,
                        Photo = "Fanta.png",
                        Piece = 1
                    },
                    new Drink
                    {
                        ID = 5,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Sprite",
                        Price = 6,
                        Photo = "Sprite.png",
                        Piece = 1
                    },
                    new Drink
                    {
                        ID = 6,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Strawberry Milkshake",
                        Price = 11,
                        Photo = "StrawberryMilkshake.png",
                        Piece = 1
                    }
                );


            //Menus
            builder.Entity<Menu>().HasData(
                    new Menu
                    {
                        ID = 1,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Whopper Menu",
                        Price = 50,
                        Photo = "WhopperMenu.png",
                        Piece = 1
                    },
                    new Menu
                    {
                        ID = 2,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "CheeseBurger Menu",
                        Price = 47,
                        Photo = "CheeseBurgerMenu.png",
                        Piece = 1
                    },
                    new Menu
                    {
                        ID = 3,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Steakhouse Burger Menu",
                        Price = 62,
                        Photo = "SteakHouseMenu.png",
                        Piece = 1
                    }
                );


            //Fries
            builder.Entity<Fries>().HasData(
                    new Fries
                    {
                        ID = 1,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Fried Potatoes",
                        Price = 10,
                        Photo = "Potatoes.png",
                        Piece = 1
                    },
                    new Fries
                    {
                        ID = 2,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Nuggets",
                        Price = 8,
                        Photo = "Nuggets.png",
                        Piece = 1
                    },
                    new Fries
                    {
                        ID = 3,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Onion Rings",
                        Price = 9,
                        Photo = "OnionRings.png",
                        Piece = 1
                    }
                );


            //Desserts
            builder.Entity<Dessert>().HasData(
                    new Dessert
                    {
                        ID = 1,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Souffle",
                        Price = 14,
                        Photo = "Souffle.png",
                        Piece = 1
                    },
                    new Dessert
                    {
                        ID = 2,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Chocolate Cookie",
                        Price = 6,
                        Photo = "ChocolateCookie.png",
                        Piece = 1
                    },
                    new Dessert
                    {
                        ID = 3,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "İce-Cream",
                        Price = 5,
                        Photo = "İceCream.png",
                        Piece = 1
                    },
                    new Dessert
                    {
                        ID = 4,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Künefe",
                        Price = 15,
                        Photo = "Künefe.png",
                        Piece = 1
                    }
                );

            //Sauces
            builder.Entity<Sauce>().HasData(
                    new Sauce
                    {
                        ID = 1,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Mayonnaise",
                        Price = 1,
                        Photo = "Mayonnaise.png",
                        Piece = 1
                    },
                    new Sauce
                    {
                        ID = 2,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Ketchup",
                        Price = 1,
                        Photo = "Ketchup.png",
                        Piece = 1
                    },
                    new Sauce
                    {
                        ID = 3,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Ranch Sauce",
                        Price = 2,
                        Photo = "RanchSauce.png",
                        Piece = 1
                    },
                    new Sauce
                    {
                        ID = 4,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        Name = "Mustard Sauce",
                        Price = 2,
                        Photo = "MustardSauce.png",
                        Piece = 1
                    }
                );

            base.OnModelCreating(builder);

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Hamburger> Hamburgers { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Fries> Fries { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Sauce> Sauces { get; set; }
    }
}