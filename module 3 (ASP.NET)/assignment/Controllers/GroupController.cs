using assignment.Controllers.Interfaces;
using assignment.Dto;
using assignment.Models;
using assignment.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : RestController<Group, GroupDto>, IGroupController
    {
        private readonly IGroupService _service;

        public GroupController(IGroupService service) : base(service)
        {
            _service = service;
        }

        [NonAction]
        public override async Task<IActionResult> Get(int id)
        {
            return await base.Get(id);
        }

        [NonAction]
        public override async Task<IActionResult> Put(int id, GroupDto request)
        {
            return await base.Put(id, request);
        }

        [NonAction]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }

        [HttpGet]
        [Authorize]
        public override async Task<IActionResult> Get()
        {
            try
            {
                int userId = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var response = _service.Get(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        [HttpGet("{groupName}")]
        [Authorize]
        public async Task<IActionResult> Get(string groupName)
        {
            try
            {
                int userId = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var response = _service.Get(groupName, userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        [HttpPost]
        [Authorize]
        public override async Task<IActionResult> Post([FromBody] GroupDto request)
        {
            try
            {
                int userId = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var response = _service.Add(userId, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        [HttpPut("{groupName}")]
        [Authorize]
        public async Task<IActionResult> Put(string groupName, [FromBody] GroupDto request)
        {
            try
            {
                int userId = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var response = _service.Update(groupName, userId, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        [HttpDelete("{groupName}")]
        [Authorize]
        public async Task<IActionResult> Delete(string groupName)
        {
            try
            {
                int userId = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var response = _service.Delete(groupName, userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        [HttpPost("add/{groupName}/{memberEmail}")]
        [Authorize]
        public async Task<IActionResult> AddMember(string groupName, string memberEmail)
        {
            try
            {
                int userId = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var response = _service.AddMember(memberEmail, groupName, userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        [HttpPost("remove/{groupName}/{memberEmail}")]
        [Authorize]
        public async Task<IActionResult> RemoveMember(string groupName, string memberEmail)
        {
            try
            {
                int userId = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var response = _service.RemoveMember(memberEmail, groupName, userId);
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
