using assignment.Data.Interfaces;
using assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment.Data
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {

        }

        public Group GetGroupWithMembers(int id)
        {
            return _dbSet
                .Include(x => x.Users)
                .FirstOrDefault(x => x.Id == id);
        }

        public Group GetGroupWithName(int id, string name)
        {
            return _dbSet
                .FirstOrDefault(x => x.Name == name && x.CreatorId == id);
        }

        public IEnumerable<Group> GetUserGroups(int id)
        {
            return _dbSet
                .Where(x => x.CreatorId == id)
                .OrderBy(x => x.CreatedAt)
                .ToList();
        }
        public void AddMembers(int id, User user)
        {
            _dbSet.Find(id).Users.Add(user);
        }

        public void RemoveMembers(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
