using Microsoft.EntityFrameworkCore.Storage;

namespace assignment.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void Save();
        IDbContextTransaction GetTransasction();
    }
}
