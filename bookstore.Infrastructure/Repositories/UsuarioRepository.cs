using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Infrastructure.Contexts;

namespace bookstore.Infrastructure.Repositories
{
    public class UsuarioRepository: BaseRepository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
