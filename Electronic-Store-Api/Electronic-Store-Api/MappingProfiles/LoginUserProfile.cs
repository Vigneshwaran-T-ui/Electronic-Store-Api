using AutoMapper;
using Electronic_Store_Api.DataModels;
using Electronic_Store_Api.ViewModels;

namespace Electronic_Store_Api.MappingProfiles
{
    public class LoginUserProfile: Profile
    {
        public LoginUserProfile() 
        {
            CreateMap<Login, LoginDM>().ForMember(dest => dest.esUserName, opt => opt.MapFrom(src => src.esUserName))
                                       .ForMember(dest => dest.esPassword, opt => opt.MapFrom(dest => dest.esPassword));
        }
    }
}
