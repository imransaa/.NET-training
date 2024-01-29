using assignment.Dto;
using assignment.Models;
using AutoMapper;

namespace assignment.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<SignupDto, User>();
            CreateMap<User, GroupUserDto>();
        }
    }
}
