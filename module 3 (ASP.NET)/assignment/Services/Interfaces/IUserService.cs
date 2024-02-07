using assignment.Dto;
using assignment.Models;

namespace assignment.Services.Interfaces
{
    public interface IUserService : IGenericService<User, UserDto>
    {
        TokenDto Signin(SigninDto signin);
        UserDto Signup(SignupDto signup); 
    }
}
