using AutoMapper;
using bookstore.Domain.Contracts.Request;
using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Services;
using bookstore.Domain.Services;
using bookstore.Domain.Shered;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
    public class ContaController : BaseController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public ContaController(IUsuarioService usuarioService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }
        [HttpPost("cadastro")]
        public async Task<ActionResult> CadastrarUsuarioAsync([FromBody] UsuarioRequest request)
        {
            var entity = _mapper.Map<Usuario>(request);
            await _usuarioService.CriarUsuarioAsync(entity);

            return Ok();
        }
        [HttpPatch("email")]
        public async Task<ActionResult> ConfirmarEmail([FromRoute] Guid tokenEmail)
        {
            throw new NotImplementedException();
        }
        [HttpPost("login")]
        public async Task<ActionResult> AuthenticarAsync([FromBody] AuthenticacaoRequest request)
        {
            var entity = await _usuarioService.ObterAsync(usuario => usuario.Email.Equals(request.Email));
            if(entity is null)
            {
                NotificarErro("Usuario não encontrado");
                return CustomResponse();
            }

            var senhaCriptografada = Cryptography.Encrypt(request.Senha);

            if(senhaCriptografada != entity.Senha)
            {
                NotificarErro("Senha incorreta");
                return CustomResponse();
            }

            return Ok(Token.GenerateToken(entity));

        }
        //[HttpPut("hash-senha")]
        //public async Task<ActionResult> EsqueciSenhaAsync([FromBody] EmailRequest emailRequest)
        //{
        //    throw new NotImplementedException();
        //}
        //[HttpPut("senha/{hash}")]
        //public async Task<IActionResult> ResetSenha([FromRoute] string hash, [FromBody] NovaSenhaRequest novaSenha)
        //{
        //    throw new NotImplementedException();

        //}
    }
}
