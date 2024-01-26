using assignment.Models;

namespace assignment.Data.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);
    }
}
