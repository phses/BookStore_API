using AutoMapper;
using bookstore.Domain.Contracts.Request;
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

        [HttpPost("avaliacao")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> PostAvaliacaoAsync([FromBody] AvaliacaoRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var entity = _mapper.Map<Avaliacao>(request);
            await _avaliacaoService.AdicionarAvalicaoAsync(entity);
            return CustomResponse();
        }

        [HttpPatch("avaliacao/{id:int}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> PatchAvaliacaoAsync([FromBody] NotaRequest request, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _avaliacaoService.AlterarNotaAvaliacaoAsync(request.Nota, id);
            return Ok();
        }
    }
}
