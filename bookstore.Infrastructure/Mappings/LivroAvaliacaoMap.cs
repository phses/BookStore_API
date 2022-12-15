using bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Infrastructure.Mappings
{
    public class LivroAvaliacaoMap : IEntityTypeConfiguration<LivroAvaliacao>
    {
        public void Configure(EntityTypeBuilder<LivroAvaliacao> builder)
        {
            builder.HasKey(x => new { x.AvaliacaoId, x.LivroId });
            builder.HasOne(x => x.Avaliacao)
                    .WithMany(x => x.LivroAvaliacoes)
                    .HasForeignKey(x => x.AvaliacaoId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Livro)
                    .WithMany(x => x.LivroAvaliacoes)
                    .HasForeignKey(x => x.LivroId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
