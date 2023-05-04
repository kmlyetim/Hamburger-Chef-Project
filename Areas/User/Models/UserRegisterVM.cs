using HamburgerMenuProject.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace HamburgerMenuProject.Models.User
{
    public class UserRegisterVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password and Confirmation Password do not match.")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
