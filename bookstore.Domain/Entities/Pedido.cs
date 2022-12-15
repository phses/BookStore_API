
namespace bookstore.Domain.Entities
{
    public class Pedido : Entity
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<LivroPedido> LivroPedidos { get; set; }
    }
}
