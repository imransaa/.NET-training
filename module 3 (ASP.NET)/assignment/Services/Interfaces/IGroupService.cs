using assignment.Dto;
using assignment.Models;

namespace assignment.Services.Interfaces
{
    public interface IGroupService : IGenericService<Group, GroupDto>
    {
        IEnumerable<GroupDto> Get(int userId);
        GroupMembersDto Get(string groupName, int userId);
        GroupDto Add(int userId, GroupDto request);
        GroupDto Update(string groupName, int userId, GroupDto request);
        GroupDto Delete(string groupName, int userId);
        GroupMembersDto AddMember(string memberEmail, string groupName, int userId);
        GroupMembersDto RemoveMember(string memberEmail, string groupName, int userId);
    }
}
