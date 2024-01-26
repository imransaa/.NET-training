using assignment.Models;

namespace assignment.Data.Interfaces
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetUserGroups(int id);
        Group GetGroupWithName(int id, string name);
        Group GetGroupWithMembers(int id);
        void AddMembers(int id, User user);
        void RemoveMembers(int id, User user);
    }
}
