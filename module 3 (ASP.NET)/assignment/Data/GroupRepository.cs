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
            Group group = _dbSet.Include(x => x.Users).FirstOrDefault(x=> x.Id == id);

            if(group != null)
            {
                Console.WriteLine("Adding member to Group ");
                group.Users.Add(user);
            }

            _dbSet.Update(group);
        }

        public void RemoveMembers(int id, User user)
        {
            Group group = _dbSet.Include(x => x.Users).FirstOrDefault(x => x.Id == id);

            if (group != null)
            {
                Console.WriteLine("Adding member to Group ");
                group.Users.Remove(user);
            }

            _dbSet.Update(group);
        }
    }
}
