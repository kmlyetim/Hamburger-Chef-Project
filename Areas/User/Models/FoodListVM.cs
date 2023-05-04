using HamburgerMenuProject.Models.Entities;

namespace HamburgerMenuProject.Models
{
    public class FoodListVM
    {
        public List<Hamburger> Hamburgers { get; set; }
        public List<Dessert> Desserts { get; set; }
        public List<Fries> Fries { get; set; }
        public List<Drink> Drinks { get; set; }
        public List<Menu> Menus { get; set; }
        public List<Sauce> Sauces { get; set; }
    }
}
