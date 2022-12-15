using bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Infrastructure.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasOne(l => l.Fornecedor).WithMany(f => f.Livros).OnDelete(DeleteBehavior.Restrict);
            builder.Property(l => l.Desconto).IsRequired(false);
            builder.Property(l => l.Imagem).IsRequired(false);
        }
    }
}
