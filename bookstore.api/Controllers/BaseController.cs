using AutoMapper;
using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Services;
using bookstore.Domain.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace bookstore.api.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("[controller]")]
    public class BaseController<TEntity, KRequest, YResponse> : ControllerBase where TEntity : Entity
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<TEntity> _service;
        private readonly INotificador _notificador;

        public BaseController(IMapper mapper, INotificador notificador, IBaseService<TEntity> service)
        {
            _mapper = mapper;
            _service = service;
            _notificador = notificador;
        }
        [HttpPost]
        [ProducesResponseType(201)]
        public virtual async Task<ActionResult> PostAsync([FromBody] KRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var entity = _mapper.Map<TEntity>(request);
            await _service.AdicionarAsync(_mapper.Map<TEntity>(request));
            return CustomResponse(entity.Id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public virtual async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] KRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var entity = _mapper.Map<TEntity>(request);
            entity.Id = id;
            await _service.AlterarAsync(entity);
            return CustomResponse();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public virtual async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _service.DeletarAsync(id);
            return CustomResponse();
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        public virtual async Task<ActionResult<List<YResponse>>> GetAsync()
        {
            var entities = await _service.ObterTodosAsync();
            var response = _mapper.Map<List<YResponse>>(entities);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public virtual async Task<ActionResult<YResponse>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await _service.ObterPorIdAsync(id);
            var response = _mapper.Map<YResponse>(entity);
            return Ok(response);
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if(OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                erros = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelStateInvalida(modelState);
            return CustomResponse();
        }

        protected void NotificarErroModelStateInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(m => m.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(erroMsg);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }


    }

}
