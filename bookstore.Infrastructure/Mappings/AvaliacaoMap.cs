using bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Infrastructure.Mappings
{
    public class AvaliacaoMap : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.HasOne(a => a.Usuario).WithMany(u => u.Avaliacoes).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
