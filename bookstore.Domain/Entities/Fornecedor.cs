using bookstore.Domain.Enums;

namespace bookstore.Domain.Entities
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor Tipo { get; set; }
        public string Email { get; set; }

        //Relacionamentos
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public IEnumerable<Livro> Livros { get; set; }
    }
}
