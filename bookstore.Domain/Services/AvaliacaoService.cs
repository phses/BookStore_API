using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;


namespace bookstore.Domain.Services
{
    public class AvaliacaoService : BaseService<Avaliacao>, IAvaliacaoService
    {

        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoService(IAvaliacaoRepository avaliacaoRepository, IHttpContextAccessor httpContextAccessor) : base(avaliacaoRepository, httpContextAccessor)
        {
        }
    }
}
