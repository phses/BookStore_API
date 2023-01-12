using AutoMapper;
using bookstore.Domain.Contracts.Request;
using bookstore.Domain.Contracts.Response;
using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
    public class FornecedorController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IFornecedorService _fornecedorService;
        public FornecedorController(IMapper mapper, INotificador notificador, IFornecedorService fornecedorService) : base(notificador)
        {
            _mapper = mapper;
            _fornecedorService = fornecedorService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public virtual async Task<ActionResult> PostAsync([FromBody] FornecedorRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var entity = _mapper.Map<Fornecedor>(request);
            await _fornecedorService.AdicionarAsync(entity);
            return CustomResponse(entity.Id);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        public virtual async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] FornecedorRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var entity = _mapper.Map<Fornecedor>(request);
            entity.Id = id;
            await _fornecedorService.AlterarAsync(entity);
            return CustomResponse();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        public virtual async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _fornecedorService.DeletarAsync(id);
            return CustomResponse();
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        public virtual async Task<ActionResult<List<FornecedorResponse>>> GetAsync()
        {
            var entities = await _fornecedorService.ObterTodosAsync();
            var response = _mapper.Map<List<FornecedorResponse>>(entities);
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        public virtual async Task<ActionResult<FornecedorResponse>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await _fornecedorService.ObterPorIdAsync(id);
            var response = _mapper.Map<FornecedorResponse>(entity);
            return Ok(response);
        }
    }
}
