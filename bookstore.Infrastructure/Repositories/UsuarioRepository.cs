using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace bookstore.Infrastructure.Repositories
{
    public class UsuarioRepository: BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly BookStoreContext _context;

        public UsuarioRepository(BookStoreContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Usuario> FindUsuarioEnderecoAsync(Expression<Func<Usuario, bool>> expression)
        {
            return await _context.Set<Usuario>().AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(expression);
        }
        public override async Task<Usuario> FindAsync(int id)
        {
            return await _context.Set<Usuario>().AsNoTracking().Include(u => u.Perfil).FirstOrDefaultAsync(u => u.Id == id);
        }
        public override async Task<Usuario> FindAsync(Expression<Func<Usuario, bool>> expression)
        {
            return await _context.Set<Usuario>().Include(u => u.Perfil).FirstOrDefaultAsync(expression);
        }
    }
}
