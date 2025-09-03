using Microsoft.EntityFrameworkCore;

namespace Utilities.Extensions
{
    public static class EFExtensions
    {
        public static Task RemoveAsync<T>(this DbSet<T> dbSet, T entity) where T : class
        {
            dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public static Task UpdateAsync<T>(this DbSet<T> dbSet, T entity) where T : class
        {
            dbSet.Update(entity);
            return Task.CompletedTask;
        }
    }
}
