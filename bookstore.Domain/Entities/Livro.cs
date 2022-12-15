namespace bookstore.Domain.Entities
{
    public class Livro : Entity
    {
        public string Titulo { get; set; }
        public double Valor { get; set; }
        public double? Desconto { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao  { get; set; }
        public string Editora { get; set; }
        public string? Imagem { get; set; }

        //Relacionamentos
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public ICollection<LivroPedido> LivroPedidos { get; set; }
        public ICollection<LivroAvaliacao> LivroAvaliacoes { get; set; }
    }
}
