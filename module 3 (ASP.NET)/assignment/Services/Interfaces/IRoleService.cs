using assignment.Dto;
using assignment.Models;

namespace assignment.Services.Interfaces
{
    public interface IRoleService : IGenericService<AuthorizationRole, RoleDto>
    {
        RoleDto Delete(string roleName);
    }
}
