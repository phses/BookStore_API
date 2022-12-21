using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace bookstore.Infrastructure.Repositories
{
    public class LivroAvaliacaoRepository : ILivroAvaliacaoRepository
    {
        private readonly BookStoreContext _context;

        public LivroAvaliacaoRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<LivroAvaliacao> FindAsync(Expression<Func<LivroAvaliacao, bool>> expression)
        {
            return await _context.Set<LivroAvaliacao>().FirstOrDefaultAsync(expression);
        }

        public async Task AddAsync(LivroAvaliacao item)
        {
            await _context.Set<LivroAvaliacao>().AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(LivroAvaliacao item)
        {
            _context.Set<LivroAvaliacao>().Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
