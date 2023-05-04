using HamburgerMenuProject.Models.BaseEntities;
using HamburgerMenuProject.Models.User;

namespace HamburgerMenuProject.Models.Entities
{
    public class Order : BaseEntity
    {
        public ICollection<Menu>? Menus { get; set; }
        public ICollection<Hamburger>? Hamburgers { get; set; }
        public ICollection<Drink>? Drinks { get; set; }
        public ICollection<Fries>? Fries { get; set; }
        public ICollection<Dessert>? Desserts { get; set; }
        public ICollection<Sauce>? Sauces { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public Order()
        {
            Menus = new HashSet<Menu>();
            Hamburgers = new HashSet<Hamburger>();
            Drinks = new HashSet<Drink>();
            Fries = new HashSet<Fries>();
            Desserts = new HashSet<Dessert>();
            Sauces = new HashSet<Sauce>();
        }
    }
}
