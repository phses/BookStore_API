using bookstore.Domain.Contracts.Request;
using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Domain.Interfaces.Services;
using bookstore.Domain.Shered;
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

        public async Task CriarUsuarioAsync(Usuario usuario)
        {
            usuario.Senha = Cryptography.Encrypt(usuario.Senha);
            usuario.DataDeCriacao = DateTime.Now;

            //Enviar email
            await _usuarioRepository.AddAsync(usuario);
        }

        public override async Task<Usuario> ObterPorIdAsync(int id)
        {
            var entity = await _usuarioRepository.FindUsuarioEnderecoAsync(x => x.Id == id && x.Ativo);
            if (entity == null)
                Notificar($"Nenhum dado encontrado para o Id {id}");
            return entity;
        }
    }
}
