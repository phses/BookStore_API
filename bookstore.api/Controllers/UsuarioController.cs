using AutoMapper;
using bookstore.Domain.Contracts.Request;
using bookstore.Domain.Contracts.Response;
using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Services;
using bookstore.Domain.Services;
using bookstore.Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
    public class UsuarioController : BaseController<Usuario, UsuarioRequest, UsuarioResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IMapper mapper, INotificador notificador, IUsuarioService UsuarioService) : base(mapper, notificador, UsuarioService)
        {
            _mapper = mapper;
            _usuarioService = UsuarioService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public override async Task<ActionResult> PostAsync([FromBody] UsuarioRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            string imgNome = Guid.NewGuid() + "_" + request.Imagem;
            if (!UploadUtil.UploadArquivo(request.ImagemUpload, imgNome))
            {
                NotificarErro("Nao foi possivel fazer o upload da imagem");
                return CustomResponse();
            }

            var entity = _mapper.Map<Usuario>(request);
            await _usuarioService.AdicionarAsync(entity);
            return CustomResponse(entity.Id);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public override async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] UsuarioRequest request)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            if (request.ImagemUpload != null)
            {
                var imgNome = Guid.NewGuid() + "_" + request.Imagem;
                if (!UploadUtil.UploadArquivo(request.ImagemUpload, imgNome))
                {
                    NotificarErro("Nao foi possivel fazer o upload da imagem");
                    return CustomResponse();
                }
            }
            var entity = _mapper.Map<Usuario>(request);
            entity.Id = id;
            await _usuarioService.AlterarAsync(entity);
            return CustomResponse(entity.Id);
        }
    }
}
