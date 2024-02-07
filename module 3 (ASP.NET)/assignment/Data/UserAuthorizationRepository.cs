using assignment.Data.Interfaces;
using assignment.Models;

namespace assignment.Data
{
    public class UserAuthorizationRepository : GenericRepository<UserAuthorization>, IUserAuthorizationRepository
    {
        public UserAuthorizationRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
