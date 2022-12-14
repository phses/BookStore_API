
using bookstore.Domain.Enums;

namespace bookstore.Domain.Contracts.Response
{
    public class FornecedorResponse : BaseResponse
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor Tipo { get; set; }
        public string Email { get; set; }
        public EnderecoResponse Endereco { get; set; }

    }
}
