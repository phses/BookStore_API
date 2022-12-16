using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;


namespace bookstore.Domain.Services
{
    public class EnderecoService : BaseService<Endereco>, IEnderecoService
    {

        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository, IHttpContextAccessor httpContextAccessor) : base(enderecoRepository, httpContextAccessor)
        {
        }
    }
}
