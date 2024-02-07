using assignment.Models;

namespace assignment.Data.Interfaces
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        IEnumerable<Group> GetUserGroups(int id);
        IEnumerable<Group> GetGroupWithMember(int id);
        Group GetGroupWithName(int id, string name);
        Group GetGroupDetails(int id);
        void AddMembers(int id, User user);
        void RemoveMembers(int id, User user);
    }
}
