using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Utilities.Extensions;

namespace Utilities.Generics
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _set;
        protected Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>>? expression = null) => expression != null ? await _set.AnyAsync(expression) : await _set.AnyAsync();

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? expression = null) => expression != null ? await _set.CountAsync(expression) : await _set.CountAsync();

        public virtual async Task CreateAsync(T entity) => await _set.AddAsync(entity);

        public async Task DeleteAsync(T entity) => await _set.RemoveAsync(entity);

        public async Task DeleteAsync(object entityKey)
        {
            T? entity = await ReadAsync(entityKey);
            if (entity != null)
            {
                await DeleteAsync(entity);
            }
        }

        public async Task<T?> FirstAsync(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
            IQueryable<T> data = expression != null ? _set.Where(expression) : _set;

            foreach (var include in includes)
            {
                data = data.Include(include);
            }

            return await data.FirstOrDefaultAsync();
        }

        public async Task<T?> ReadAsync(object entityKey) => await _set.FindAsync(entityKey);

        public async Task<IEnumerable<T>> ReadAsync(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
            IQueryable<T> data = expression != null ? _set.Where(expression) : _set;

            foreach (var include in includes)
            {
                data = data.Include(include);
            }

            return await data.ToListAsync();
        }

        public async Task UpdateAsync(T entity) => await _set.UpdateAsync(entity);
    }
}
