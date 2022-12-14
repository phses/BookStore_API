
using System.ComponentModel.DataAnnotations;


namespace bookstore.Domain.Contracts.Request
{
    public class PedidoRequest
    {
        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} e obrigatorio")]
        public IEnumerable<int> LivrosId { get; set; }
    }
}
