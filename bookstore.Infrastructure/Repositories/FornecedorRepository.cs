using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace bookstore.Infrastructure.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        private readonly BookStoreContext _context;
        public FornecedorRepository(BookStoreContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Fornecedor> FindFornecedorEnderecoAsync(Expression<Func<Fornecedor, bool>> expression)
        {
            return await _context.Set<Fornecedor>().AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(expression);
        }
    }
}
