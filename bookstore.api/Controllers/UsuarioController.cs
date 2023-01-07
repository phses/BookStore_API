using AutoMapper;
using bookstore.Domain.Contracts.Request;
using bookstore.Domain.Contracts.Response;
using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Services;
using bookstore.Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IMapper mapper, INotificador notificador, IUsuarioService UsuarioService) : base(notificador)
        {
            _mapper = mapper;
            _usuarioService = UsuarioService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult> PostAsync([FromBody] UsuarioRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            string imgNome = Guid.NewGuid() + "_" + request.Imagem;
            if (!UploadUtil.UploadArquivo(request.ImagemUpload, imgNome))
            {
                NotificarErro("Nao foi possivel fazer o upload da imagem");
                return CustomResponse();
            }

            var entity = _mapper.Map<Usuario>(request);
            entity.ImagemPerfil = imgNome;
            await _usuarioService.AdicionarAsync(entity);
            return CustomResponse(entity.Id);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] UsuarioRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var imgNome = "";
            if (request.ImagemUpload != null)
            {
                imgNome = Guid.NewGuid() + "_" + request.Imagem;
                if (!UploadUtil.UploadArquivo(request.ImagemUpload, imgNome))
                {
                    NotificarErro("Nao foi possivel fazer o upload da imagem");
                    return CustomResponse();
                }
            }
            var entity = _mapper.Map<Usuario>(request);
            entity.Id = id;
            entity.ImagemPerfil = imgNome;
            await _usuarioService.AlterarAsync(entity);
            return CustomResponse(entity.Id);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _usuarioService.DeletarAsync(id);
            return CustomResponse();
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        public virtual async Task<ActionResult<List<UsuarioResponse>>> GetAsync()
        {
            var entities = await _usuarioService.ObterTodosAsync();
            var response = _mapper.Map<List<UsuarioResponse>>(entities);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public virtual async Task<ActionResult<UsuarioResponse>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await _usuarioService.ObterPorIdAsync(id);
            var response = _mapper.Map<UsuarioResponse>(entity);
            return Ok(response);
        }

        [HttpPost("avaliacao")]
        [ProducesResponseType(200)]
        public virtual async Task<ActionResult> PostAvaliacaoAsync([FromBody] AvaliacaoRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var entity = _mapper.Map<Avaliacao>(request);
            await _usuarioService.AdicionarAvalicaoAsync(entity);
            return CustomResponse();
        }
    }
}
