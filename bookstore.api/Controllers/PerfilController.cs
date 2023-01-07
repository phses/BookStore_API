using AutoMapper;
using bookstore.Domain.Contracts.Request;
using bookstore.Domain.Contracts.Response;
using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
    public class PerfilController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IPerfilService _perfilService;

        public PerfilController(IMapper mapper, 
                                INotificador notificador, 
                                IPerfilService perfilService) : base(notificador)
        {
            _mapper = mapper;
            _perfilService = perfilService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult> PostAsync([FromBody] PerfilRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var entity = _mapper.Map<Perfil>(request);
            await _perfilService.AdicionarAsync(entity);
            return CustomResponse(entity.Id);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        public virtual async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] PerfilRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var entity = _mapper.Map<Perfil>(request);
            entity.Id = id;
            await _perfilService.AlterarAsync(entity);
            return CustomResponse();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        public virtual async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _perfilService.DeletarAsync(id);
            return CustomResponse();
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        public virtual async Task<ActionResult<List<PerfilResponse>>> GetAsync()
        {
            var entities = await _perfilService.ObterTodosAsync();
            var response = _mapper.Map<List<PerfilResponse>>(entities);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public virtual async Task<ActionResult<PerfilResponse>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await _perfilService.ObterPorIdAsync(id);
            var response = _mapper.Map<PerfilResponse>(entity);
            return Ok(response);
        }
    }
}
