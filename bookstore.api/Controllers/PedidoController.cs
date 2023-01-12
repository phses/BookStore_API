using AutoMapper;
using bookstore.Domain.Contracts.Request;
using bookstore.Domain.Contracts.Response;
using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Services;
using bookstore.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
    public class PedidoController : BaseController
    {
        private readonly IPedidoService _pedidoService;
        private readonly IMapper _mapper;

        public PedidoController(INotificador notificador, IPedidoService pedidoService, IMapper mapper) : base(notificador)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public virtual async Task<ActionResult> PostAsync([FromBody] PedidoRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var entity = _mapper.Map<Pedido>(request);
            await _pedidoService.AdicionarAsync(entity);
            return CustomResponse(entity.Id);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        public virtual async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] PedidoRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var entity = _mapper.Map<Pedido>(request);
            entity.Id = id;
            await _pedidoService.AlterarAsync(entity);
            return CustomResponse();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        public virtual async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _pedidoService.DeletarAsync(id);
            return CustomResponse();
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        public virtual async Task<ActionResult<List<PedidoResponse>>> GetAsync()
        {
            var entities = await _pedidoService.ObterTodosAsync();
            var response = _mapper.Map<List<PedidoResponse>>(entities);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        public virtual async Task<ActionResult<PedidoResponse>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await _pedidoService.ObterPorIdAsync(id);
            var response = _mapper.Map<PedidoResponse>(entity);
            return Ok(response);
        }
    }
}
