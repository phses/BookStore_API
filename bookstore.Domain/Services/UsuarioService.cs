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

        public async Task AdicionarAvalicaoAsync(Avaliacao entity)
        {
            var find = await _avaliacaoRepository.FindAsync(entity.Id);
            if(find != null)
            {
                Notificar("Ja existe uma avaliacao com o id informado");
                return;
            }
            entity.DataDeCriacao = DateTime.Now;
            entity.Ativo = true;
            await _avaliacaoRepository.AddAsync(entity);
        }

        public async Task AlterarNotaAvaliacaoAsync(int nota, int id)
        {
            var entity = await _avaliacaoRepository.FindAsync(id);
            if(entity == null)
            {
                Notificar("Nao existe uma avaliacao com o id informado");
                return;
            }
            entity.DataDeAlteracao = DateTime.Now;
            entity.Nota = nota;
            await _avaliacaoRepository.EditAsync(entity);
        }
    }
}
