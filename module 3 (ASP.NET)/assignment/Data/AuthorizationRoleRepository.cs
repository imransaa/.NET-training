using assignment.Data.Interfaces;
using assignment.Models;

namespace assignment.Data
{
    public class AuthorizationRoleRepository : GenericRepository<AuthorizationRole>, IAuthorizationRoleRepository
    {
        public AuthorizationRoleRepository(AppDbContext context) : base(context)
        {
            
        }

        public AuthorizationRole GetRole(string role)
        {
            return _dbSet.FirstOrDefault(x => x.Role == role);
        }
    }
}
