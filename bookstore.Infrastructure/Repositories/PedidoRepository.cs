using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Infrastructure.Contexts;


namespace bookstore.Infrastructure.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {

        public PedidoRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
