using assignment.Dto;
using assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace assignment.Controllers.Interfaces
{
    public interface IUserController : IRestController<UserDto>
    {
        Task<IActionResult> Signin([FromBody] SigninDto signin);
        Task<IActionResult> Signup([FromBody] SignupDto signup);
    }
}
