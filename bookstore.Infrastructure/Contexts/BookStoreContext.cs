using bookstore.Domain.Entities;
using bookstore.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;


namespace bookstore.Infrastructure.Contexts
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<LivroPedido> LivroPedidos { get; set; }
        public DbSet<LivroAvaliacao> LivroAvaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LivroPedido>(new LivroPedidoMap().Configure);
            modelBuilder.Entity<LivroAvaliacao>(new LivroAvaliacaoMap().Configure);
        }
        
    }
}
