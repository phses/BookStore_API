using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Infrastructure.Contexts;


namespace bookstore.Infrastructure.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {

        public FornecedorRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
