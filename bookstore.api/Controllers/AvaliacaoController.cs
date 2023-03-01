using AutoMapper;
using bookstore.Domain.Contracts.Request;
using bookstore.Domain.Contracts.Response;
using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
    public class AvaliacaoController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(IMapper mapper, 
                                   IAvaliacaoService avaliacaoService, 
                                   INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _avaliacaoService = avaliacaoService;
        }

        [HttpPost("")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> PostAvaliacaoAsync([FromBody] AvaliacaoRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var entity = _mapper.Map<Avaliacao>(request);
            await _avaliacaoService.AdicionarAvalicaoAsync(entity);
            return CustomResponse(entity.Id);
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> PatchAvaliacaoAsync([FromBody] NotaRequest request, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _avaliacaoService.AlterarNotaAvaliacaoAsync(request.Nota, id);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> DeleteAvaliacaAsync([FromRoute] int id)
        {
            await _avaliacaoService.DeletarAsync(id);
            return CustomResponse();
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<AvaliacaoResponse>>> GetAsync()
        {
            var entitie = await _avaliacaoService.ObterTodosAsync();
            var response = _mapper.Map<IEnumerable<Avaliacao>, IEnumerable<AvaliacaoResponse>>(entitie);
            if(!response.Any())
            {
                return NoContent();
            }
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<AvaliacaoResponse>>> GetByIdAsync([FromRoute] int id)
        {
            var entitie = await _avaliacaoService.ObterPorIdAsync(id);
            var response = _mapper.Map<Avaliacao, AvaliacaoResponse>(entitie);
            return Ok(response);
        }
    }
}
