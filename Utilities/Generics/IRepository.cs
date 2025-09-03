using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Utilities.Generics
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T?> ReadAsync(object entityKey);
        Task<IEnumerable<T>> ReadAsync(Expression<Func<T, bool>>? expression = null, params string[] includes);
        Task<T?> FirstAsync(Expression<Func<T, bool>>? expression = null, params string[] includes);
        Task<bool> AnyAsync(Expression<Func<T, bool>>? expression = null);
        Task<int> CountAsync(Expression<Func<T, bool>>? expression = null);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(object entityKey);
    }

    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _set;
        protected Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<T, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(object entityKey)
        {
            throw new NotImplementedException();
        }

        public Task<T?> FirstAsync(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<T?> ReadAsync(object entityKey)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ReadAsync(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
