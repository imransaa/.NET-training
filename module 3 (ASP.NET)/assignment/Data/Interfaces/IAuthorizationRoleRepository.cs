using assignment.Models;

namespace assignment.Data.Interfaces
{
    public interface IAuthorizationRoleRepository
    {
        AuthorizationRole GetRole(string role);  
    }
}
