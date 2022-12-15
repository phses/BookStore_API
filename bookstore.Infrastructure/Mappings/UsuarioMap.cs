using bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace bookstore.Infrastructure.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.SenhaToken).IsRequired(false);
            builder.Property(u => u.ImagemPerfil).IsRequired(false);
            builder.HasOne(u => u.Perfil).WithMany(p => p.Usuarios).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(u => u.Endereco).WithOne().IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
