using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Domain.Interfaces.Services;
using bookstore.Domain.Notificacoes;
using bookstore.Domain.Utils;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;
using System.Security.Claims;


namespace bookstore.Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : Entity
    {
        private readonly IBaseRepository<T> _repository;
        private readonly INotificador _notificador;
        public readonly int? UserId;
        public readonly string UserPerfil;

        public BaseService(IBaseRepository<T> repository,INotificador notificador,
            IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _notificador = notificador;
            UserId = httpContextAccessor.HttpContext.GetClaim(ClaimTypes.NameIdentifier).ToInt();
            UserPerfil = httpContextAccessor.HttpContext.GetClaim(ClaimTypes.Role);
        }

        public virtual async Task<List<T>> ObterTodosAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.ListAsync(expression);
        }

        public virtual async Task<T> ObterAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await _repository.FindAsync(expression);
            if (entity == null)
                Notificar("Nenhum dado encontrado");

            return entity;
        }

        public virtual async Task<List<T>> ObterTodosAsync()
        {
            return await _repository.ListAsync(x => x.Ativo);
        }

        public virtual async Task<T> ObterPorIdAsync(int id)
        {
            var entity = await _repository.FindAsync(x => x.Id == id && x.Ativo);
            if (entity == null)
                Notificar($"Nenhum dado encontrado para o Id {id}");
            return entity;
        }

        public virtual async Task AdicionarAsync(T entity)
        {
            entity.DataDeCriacao = DateTime.Now;
            await _repository.AddAsync(entity);
        }

        public virtual async Task DeletarAsync(int id)
        {
            var entity = await _repository.FindAsync(id);
            if (entity == null)
                Notificar($"Nenhum dado encontrado para o Id {id}");

            entity.DataDeAlteracao = DateTime.Now;
            entity.Ativo = false;
            await _repository.EditAsync(entity);

        }

        public virtual async Task AlterarAsync(T entity)
        {

            var find = await _repository.FindAsNoTrackingAsync(x => x.Id == entity.Id && x.Ativo);
            if (find == null)
                Notificar($"Nenhum dado encontrado para o Id {entity.Id}");

            entity.DataDeCriacao = find.DataDeCriacao;
            entity.DataDeAlteracao = DateTime.Now;
            await _repository.EditAsync(entity);
        }
        
        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }

}
