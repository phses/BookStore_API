using bookstore.Domain.Contracts.Request;
using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace bookstore.Domain.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, INotificador notificador, IHttpContextAccessor httpContextAccessor, IAvaliacaoRepository avaliacaoRepository) : base(usuarioRepository, notificador, httpContextAccessor)
        {
            _usuarioRepository = usuarioRepository;
            _avaliacaoRepository = avaliacaoRepository;
        }
    }
}
