
using bookstore.Domain.Entities;

namespace bookstore.Domain.Contracts.Response
{
    public class LivroResponse : BaseResponse
    {
        public string Titulo { get; set; }
        public double Valor { get; set; }
        public double? Desconto { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Editora { get; set; }
        public string? Imagem { get; set; }
    }
}
