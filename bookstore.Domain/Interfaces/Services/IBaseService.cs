
using bookstore.Domain.Entities;
using System.Linq.Expressions;

namespace bookstore.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : Entity
    {
        Task<List<T>> ObterTodosAsync(Expression<Func<T, bool>> expression);
        Task<T> ObterAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> ObterTodosAsync();
        Task<T> ObterPorIdAsync(int id);
        Task AdicionarAsync(T entity);
        Task DeletarAsync(int id);
        Task AlterarAsync(T entity);

    }
}
