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

        public Group GetGroupDetails(int id)
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
            Group group = _dbSet.Include(x => x.Users).FirstOrDefault(x=> x.Id == id);

            if(group != null)
            {
                group.Users.Add(user);
            }

            _dbSet.Update(group);
        }

        public void RemoveMembers(int id, User user)
        {
            Group group = _dbSet.Include(x => x.Users).FirstOrDefault(x => x.Id == id);

            if (group != null)
            {
                group.Users.Remove(user);
            }

            _dbSet.Update(group);
        }

        public IEnumerable<Group> GetGroupWithMember(int id)
        {
            return _dbSet
                .Include(x => x.Users)
                .Where(x => x.Users.Where(y => y.Id == id).Any());
        }
    }
}
