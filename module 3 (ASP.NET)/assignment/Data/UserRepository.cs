using assignment.Data.Interfaces;
using assignment.Models;

namespace assignment.Data
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
            
        }

        public User GetUserByEmail(string email)
        {
            return _dbSet.FirstOrDefault(x => x.Email == email);  
        }
    }
}
