using AutoMapper;
using Azure.Core;
using bookstore.Domain.Contracts.Request;
using bookstore.Domain.Contracts.Response;
using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Services;
using bookstore.Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
    public class LivroController : BaseController<Livro, LivroRequest, LivroResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILivroService _livroService;
        public LivroController(IMapper mapper, INotificador notificador, ILivroService livroService) : base(mapper, notificador, livroService)
        {
            _mapper = mapper;
            _livroService = livroService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public override async Task<ActionResult> PostAsync([FromBody] LivroRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            string imgNome = Guid.NewGuid() + "_" + request.Imagem;
            if (!UploadUtil.UploadArquivo(request.ImagemUpload, imgNome))
            {
                NotificarErro("Nao foi possivel fazer o upload da imagem");
                return CustomResponse();
            }

            var entity = _mapper.Map<Livro>(request);
            await _livroService.AdicionarAsync(entity);
            return CustomResponse(entity.Id);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public override async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] LivroRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            if(request.ImagemUpload != null)
            {
                var imgNome = Guid.NewGuid() + "_" + request.Imagem;
                if (!UploadUtil.UploadArquivo(request.ImagemUpload, imgNome))
                {
                    NotificarErro("Nao foi possivel fazer o upload da imagem");
                    return CustomResponse();
                }
            }
            var entity = _mapper.Map<Livro>(request);
            entity.Id = id;
            await _livroService.AlterarAsync(entity);
            return CustomResponse(entity.Id);
        }

    }
}
