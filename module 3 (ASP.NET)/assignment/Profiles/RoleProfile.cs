using assignment.Dto;
using assignment.Models;
using AutoMapper;

namespace assignment.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDto, AuthorizationRole>();
            CreateMap<AuthorizationRole, RoleDto>();
        }
    }
}
