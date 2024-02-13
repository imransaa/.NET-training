using assignment.Dto;
using assignment.Models;
using AutoMapper;

namespace assignment.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<GroupDto, Group>();
            CreateMap<Group, GroupDto>();
            CreateMap<Group, GroupDetailsDto>();
            CreateMap<Group, GroupMembersDto>();
        }
    }
}
