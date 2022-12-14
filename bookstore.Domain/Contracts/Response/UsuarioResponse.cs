using bookstore.Domain.Entities;
using bookstore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore.Domain.Contracts.Response
{
    public class UsuarioResponse : BaseResponse
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string? ImagemPerfil { get; set; }
        public EnderecoResponse Endereco { get; set; }
    }
}
