
using bookstore.Domain.Entities;

namespace bookstore.Domain.Interfaces.Services
{
    public interface IAvaliacaoService : IBaseService<Avaliacao>
    {
        Task AdicionarAvalicaoAsync(Avaliacao entity);
        Task AlterarNotaAvaliacaoAsync(int nota, int id);
    }
}
