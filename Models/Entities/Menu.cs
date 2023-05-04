using HamburgerMenuProject.Models.BaseEntities;

namespace HamburgerMenuProject.Models.Entities
{
    public class Menu : BaseEntity
    {
        public ICollection<Hamburger> Hamburgers { get; set; }
        public ICollection<Drink> Drinks { get; set; }
        public ICollection<Fries> Fries { get; set; }
        public ICollection<Dessert> Desserts { get; set; }
        public ICollection<Sauce> Sauces { get; set; }

        public Menu()
        {
            Hamburgers = new HashSet<Hamburger>();
            Drinks = new HashSet<Drink>();
            Fries = new HashSet<Fries>();
            Desserts = new HashSet<Dessert>();
            Sauces = new HashSet<Sauce>(); 
        }
    }
}
