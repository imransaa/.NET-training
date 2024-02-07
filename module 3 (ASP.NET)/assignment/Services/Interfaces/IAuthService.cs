using assignment.Models;

namespace assignment.Services.Interfaces
{
    public interface IAuthService
    {
        string GetToken(User user);
        string HashPasword(string password, out string salt);
        bool VerifyPassword(string password, string hash, string salt);
    }
}
