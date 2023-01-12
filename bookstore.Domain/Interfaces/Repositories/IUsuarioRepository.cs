using bookstore.Domain.Entities;
using System.Linq.Expressions;


namespace bookstore.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> FindUsuarioEnderecoAsync(Expression<Func<Usuario, bool>> expression);
    }
}
