using HamburgerMenuProject.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace HamburgerMenuProject.Models.User
{
    public class AppUser : IdentityUser
    {
        public string? WhoAdded { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
