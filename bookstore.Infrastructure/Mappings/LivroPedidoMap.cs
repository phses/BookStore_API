using bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bookstore.Infrastructure.Mappings
{
    public class LivroPedidoMap : IEntityTypeConfiguration<LivroPedido>
    {
        public void Configure(EntityTypeBuilder<LivroPedido> builder)
        {
            builder.HasKey(x => new { x.PedidoId, x.LivroId });
            builder.HasOne(x => x.Pedido)
                    .WithMany(x => x.LivroPedidos)
                    .HasForeignKey(x => x.LivroId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Livro)
                    .WithMany(x => x.LivroPedidos)
                    .HasForeignKey(x => x.LivroId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
