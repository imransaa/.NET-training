using assignment.Dto;
using Microsoft.AspNetCore.Mvc;

namespace assignment.Controllers.Interfaces
{
    public interface IRoleController : IRestController<RoleDto>
    {
        Task<IActionResult> Delete(string role);
    }
}
