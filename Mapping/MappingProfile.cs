using AutoMapper;
using HamburgerMenuProject.Models.User;

namespace MVC_IdentityManager.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterVM, AppUser>().ReverseMap();
            CreateMap<UserLoginVM, AppUser>().ReverseMap();
        }
    }
}
