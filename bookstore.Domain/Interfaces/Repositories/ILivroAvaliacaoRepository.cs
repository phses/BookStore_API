using bookstore.Domain.Entities;
using System.Linq.Expressions;


namespace bookstore.Domain.Interfaces.Repositories
{
    public interface ILivroAvaliacaoRepository 
    {
        Task<LivroAvaliacao> FindAsync(Expression<Func<LivroPedido, bool>> expression);
        Task AddAsync(LivroAvaliacao item);
        Task RemoveAsync(LivroAvaliacao item);
    }
}
