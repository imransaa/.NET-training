using assignment.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace assignment.Data
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>  where TEntity : class
    {
        private AppDbContext _context;
        protected DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null, string? include = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            if(include != null)
            {
                foreach (var property in include.Split(',', StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(property);
                }
            }

            return query.ToList();
        }

        public virtual TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual EntityEntry<TEntity> Add(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual EntityEntry<TEntity> Update(TEntity entity)
        {
            return _dbSet.Update(entity);
        }

        public virtual EntityEntry<TEntity> Delete(int id)
        {
            TEntity entity = Get(id);
            return Delete(entity);
        }

        public virtual EntityEntry<TEntity> Delete(TEntity entity)
        {
            if(_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            return _dbSet.Remove(entity);
        }
    }
}
