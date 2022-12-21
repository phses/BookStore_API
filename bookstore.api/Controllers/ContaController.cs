//using bookstore.Domain.Contracts.Request;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace bookstore.api.Controllers
//{
//    public class ContaController : ControllerBase
//    {
//        [HttpPost("cadastro")]
//        public async Task<ActionResult> CadastrarUsuarioAsync([FromBody] UsuarioRequest request)
//        {
//            throw new NotImplementedException();
//        }
//        [HttpPatch("email")]
//        public async Task<ActionResult> ConfirmarEmail([FromRoute] Guid tokenEmail)
//        {
//            throw new NotImplementedException();
//        }
//        [HttpPost("login")]
//        public async Task<ActionResult> AuthenticarAsync([FromBody] AuthenticacaoRequest request)
//        {
//            throw new NotImplementedException();
//        }
//        [HttpPut("hash-senha")]
//        public async Task<ActionResult> EsqueciSenhaAsync([FromBody] EmailRequest emailRequest)
//        {
//            throw new NotImplementedException();
//        }
//        [HttpPut("senha/{hash}")]
//        public async Task<IActionResult> ResetSenha([FromRoute] string hash, [FromBody] NovaSenhaRequest novaSenha)
//        {
//            throw new NotImplementedException();

//        }
//    }
//}
