
using bookstore.Domain.Entities;
using System.Linq.Expressions;

namespace bookstore.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<T> FindAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<T> FindAsNoTrackingAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> ListAsync();
        Task<List<T>> ListAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T item);
        Task RemoveAsync(T item);
        Task EditAsync(T item);
    }
}
