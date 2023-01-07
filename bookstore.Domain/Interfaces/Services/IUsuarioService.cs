
using bookstore.Domain.Entities;

namespace bookstore.Domain.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        Task AdicionarAvalicaoAsync(Avaliacao entity);
    }
}
