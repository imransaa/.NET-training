using assignment.Models;

namespace assignment.Data.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserByEmail(string email);
    }
}
