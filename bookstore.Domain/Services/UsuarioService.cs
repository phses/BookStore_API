using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace bookstore.Domain.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, IHttpContextAccessor httpContextAccessor) : base(usuarioRepository, httpContextAccessor)
        {
        }
    }
}
