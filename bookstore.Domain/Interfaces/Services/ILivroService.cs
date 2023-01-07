
using bookstore.Domain.Entities;

namespace bookstore.Domain.Interfaces.Services
{
    public interface ILivroService : IBaseService<Livro>
    {
        Task<IEnumerable<Livro>> ObterPaginacaoAsync(int skip, int take);
    }
}
