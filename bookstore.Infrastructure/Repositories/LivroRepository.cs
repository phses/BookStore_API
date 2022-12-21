using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Infrastructure.Contexts;


namespace bookstore.Infrastructure.Repositories
{
    public class LivroRepository : BaseRepository<Livro>, ILivroRepository
    {

        public LivroRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
