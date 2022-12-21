using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Infrastructure.Contexts;

namespace bookstore.Infrastructure.Repositories
{
    public class AvaliacaoRepository : BaseRepository<Avaliacao>, IAvaliacaoRepository
    {

        public AvaliacaoRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
