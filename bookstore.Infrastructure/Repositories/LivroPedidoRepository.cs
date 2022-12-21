using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace bookstore.Infrastructure.Repositories
{
    public class LivroPedidoRepository: ILivroPedidoRepository
    {
        private readonly BookStoreContext _context;

        public LivroPedidoRepository(BookStoreContext context) 
        {
            _context = context;
        }

        public async Task<LivroPedido> FindAsync(Expression<Func<LivroPedido, bool>> expression)
        {
            return await _context.Set<LivroPedido>().FirstOrDefaultAsync(expression);
        }

        public async Task AddAsync(LivroPedido item)
        {
            await _context.Set<LivroPedido>().AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(LivroPedido item)
        {
            _context.Set<LivroPedido>().Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
