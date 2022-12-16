using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;


namespace bookstore.Domain.Services
{
    public class FornecedorService : BaseService<Fornecedor>, IFornecedorService
    {

        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IHttpContextAccessor httpContextAccessor) : base(fornecedorRepository, httpContextAccessor)
        {
        }
    }
}
