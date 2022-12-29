using AutoMapper;
using Azure.Core;
using bookstore.Domain.Contracts.Request;
using bookstore.Domain.Contracts.Response;
using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Services;
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

            string imgNome = new Guid() + "_" + request.Imagem;
            if (!UploadArquivo(request.ImagemUpload, imgNome))
            {
                return CustomResponse();
            }

            var entity = _mapper.Map<Livro>(request);
            await _livroService.AdicionarAsync(entity);
            return CustomResponse(entity);
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            var imgDataByteArray = Convert.FromBase64String(arquivo);

            if(string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneca uma imagem para este produto");
                return false;
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwRoot/Imagens", imgNome);

            if(System.IO.File.Exists(filePath))
            {
                NotificarErro("Ja existe um arquivo com este nome");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imgDataByteArray);
            return true;
        }
    }
}
