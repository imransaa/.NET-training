using assignment.Models;

namespace assignment.Data.Interfaces
{
    public interface IAuthorizationRoleRepository : IGenericRepository<AuthorizationRole>
    {
        AuthorizationRole GetRole(string role);  
    }
}
