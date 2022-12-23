using bookstore.Domain.Interfaces.Repositories;
using bookstore.Domain.Interfaces.Services;
using bookstore.Domain.Services;
using bookstore.Infrastructure.Repositories;

namespace bookstore.api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IAvaliacaoService, AvaliacaoService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            #endregion
            #region Repository
            services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILivroAvaliacaoRepository, LivroAvaliacaoRepository>();
            services.AddScoped<ILivroPedidoRepository, LivroPedidoRepository>();
            #endregion
        }
    }
}
