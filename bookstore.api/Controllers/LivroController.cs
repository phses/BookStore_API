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
    public class LivroController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILivroService _livroService;
        public LivroController(IMapper mapper, INotificador notificador, ILivroService livroService) : base(notificador)
        {
            _mapper = mapper;
            _livroService = livroService;
        }
        // Há um limite no tamanho da imagem para este método, existem outras formas que permitem um tamanho de imagem maior
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult> PostAsync([FromBody] LivroRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            string imgNome = Guid.NewGuid() + "_" + request.Imagem;
            if (!UploadUtil.UploadArquivo(request.ImagemUpload, imgNome))
            {
                NotificarErro("Nao foi possivel fazer o upload da imagem");
                return CustomResponse();
            }

            var entity = _mapper.Map<Livro>(request);
            entity.Imagem = imgNome;
            await _livroService.AdicionarAsync(entity);
            return CustomResponse(entity.Id);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] LivroRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            var imgNome = "";
            if(request.ImagemUpload != null)
            {
                imgNome = Guid.NewGuid() + "_" + request.Imagem;
                if (!UploadUtil.UploadArquivo(request.ImagemUpload, imgNome))
                {
                    NotificarErro("Nao foi possivel fazer o upload da imagem");
                    return CustomResponse();
                }
            }
            var entity = _mapper.Map<Livro>(request);
            entity.Id = id;
            entity.Imagem = imgNome;
            await _livroService.AlterarAsync(entity);
            return CustomResponse(entity.Id);
        }
        //Fazer melhorias na paginação, incluir ordenação e pagina
        [HttpGet()]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<LivroResponse>>> GetAsync([FromQuery] int skip = 0,
                                                                      [FromQuery] int take = 25)
        {
            var entities = await _livroService.ObterPaginacaoAsync(skip, take);
            var response = _mapper.Map<List<LivroResponse>>(entities);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public virtual async Task<ActionResult<LivroResponse>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await _livroService.ObterPorIdAsync(id);
            var response = _mapper.Map<LivroResponse>(entity);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public virtual async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _livroService.DeletarAsync(id);
            return CustomResponse();
        }

    }
}
