using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace assignment.Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null, string? include = null);
        TEntity Get(int id);
        EntityEntry<TEntity> Add(TEntity entity);
        EntityEntry<TEntity> Update(TEntity entity);
        EntityEntry<TEntity> Delete(int id);
        EntityEntry<TEntity> Delete(TEntity entity);
    }
}
