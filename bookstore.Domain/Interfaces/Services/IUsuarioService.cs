
using bookstore.Domain.Entities;

namespace bookstore.Domain.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        public Task CriarUsuarioAsync(Usuario user);
    }
}
