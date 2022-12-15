using bookstore.Domain.Entities;
using System.Linq.Expressions;

namespace bookstore.Domain.Interfaces.Repositories
{
    public interface ILivroPedidoRepository 
    {
        Task<LivroPedido> FindAsync(Expression<Func<LivroPedido, bool>> expression);
        Task AddAsync(LivroPedido item);
        Task RemoveAsync(LivroPedido item);
    }
}
