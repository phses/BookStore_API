using bookstore.Domain.Enums;

namespace bookstore.Domain.Entities
{
    public class Usuario : Entity
    {
        public Usuario()
        {
            EmailToken = Guid.NewGuid();
            EmailConfirmado = false;
        }

        public string Nome { get; set; }
        public string Senha { get; set; }
        public string? SenhaToken { get; set; }
        public DateTime? SenhaTokenExpira { get; set; }
        public string Email { get; set; }
        public Guid EmailToken { get; set; }
        public bool EmailConfirmado { get; set; }
        public string? ImagemPerfil { get; set; }

        //Relacionamentos
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }

        public IEnumerable<Avaliacao> Avaliacoes { get; set; }
        public IEnumerable<Pedido> Pedidos { get; set;  }

    }   
}
