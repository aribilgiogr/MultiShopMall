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
}
