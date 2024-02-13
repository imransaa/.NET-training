using assignment.Controllers.Interfaces;
using assignment.Dto;
using assignment.Models;
using assignment.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : RestController<AuthorizationRole, RoleDto>, IRoleController
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service) : base(service)
        {
            _service = service;
        }

        [NonAction]
        public override async Task<IActionResult> Get(int id)
        {
            return await base.Get(id);
        }

        [NonAction]
        public override async Task<IActionResult> Put(int id, RoleDto request)
        {
            return await base.Put(id, request);
        }

        [NonAction]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }

        [HttpDelete("{roleName}")]
        [Authorize]
        public async Task<IActionResult> Delete(string roleName)
        {
            try
            {
                var response = _service.Delete(roleName);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }
    }
}
