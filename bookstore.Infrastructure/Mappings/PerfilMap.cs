using bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace bookstore.Infrastructure.Mappings
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.HasData(new Perfil
            {
                Id = 1,
                Nome = "Administrador",
                Ativo= true,
                DataDeCriacao = DateTime.Now
            });
            builder.HasData(new Perfil
            {
                Id = 2,
                Nome = "Cliente",
                Ativo= true,
                DataDeCriacao = DateTime.Now
            });
        }
    }
}
