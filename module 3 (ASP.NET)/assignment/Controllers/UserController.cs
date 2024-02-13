using assignment.Controllers.Interfaces;
using assignment.Dto;
using assignment.Models;
using assignment.Services.Interfaces;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : RestController<User, UserDto>, IUserController
    {
        private readonly IUserService _service;

        public UserController(IUserService service) : base(service)
        {
            _service = service;
        }

        [NonAction]
        public override async Task<IActionResult> Get()
        {
            return await base.Get();
        }

        [NonAction]
        public override async Task<IActionResult> Get(int id)
        {
            return await base.Get(id);
        }


        [NonAction]
        public override async Task<IActionResult> Post(UserDto request)
        {
            return await base.Post(request);
        }

        [NonAction]
        public override async Task<IActionResult> Put(int id, UserDto request)
        {
            return await base.Put(id, request);
        }

        [NonAction]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }

        // POST api/<GroupController>/signin
        [HttpPost("signin")]
        public async Task<IActionResult> Signin([FromBody] SigninDto signin)
        {
            try
            {
                var response = _service.Signin(signin);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        // POST api/<GroupController>/signup
        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupDto signup)
        {
            try
            {
                var response = _service.Signup(signup);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }
        }

        // DELETE api/<GroupController>/5
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete()
        {
            int userId = int.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await Delete(userId);
        }
    }
}
