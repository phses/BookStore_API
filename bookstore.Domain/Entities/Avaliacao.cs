
namespace bookstore.Domain.Entities
{
    public class Avaliacao : Entity
    {
        public int Nota { get; set; }

        //Relacionamento
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<LivroAvaliacao> LivroAvaliacoes { get; set; }
    }
}
