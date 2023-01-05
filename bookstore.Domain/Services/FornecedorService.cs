using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Domain.Interfaces.Services;
using bookstore.Domain.Validations;
using Microsoft.AspNetCore.Http;


namespace bookstore.Domain.Services
{
    public class FornecedorService : BaseService<Fornecedor>, IFornecedorService
    {

        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository, 
                                 INotificador notificador, 
                                 IHttpContextAccessor httpContextAccessor) : base(fornecedorRepository, notificador, httpContextAccessor)
        {
            _fornecedorRepository = fornecedorRepository;
        }
        public override async Task AdicionarAsync(Fornecedor entity)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), entity)) return;
            entity.Ativo = true;
            entity.DataDeCriacao = DateTime.Now;
            await _fornecedorRepository.AddAsync(entity);
        }
        public async Task<Fornecedor> ObterFornecedorEnderecoAsync(int id)
        {
            var entity = await _fornecedorRepository.FindFornecedorEnderecoAsync(x => x.Id == id && x.Ativo);
            if (entity == null)
                Notificar($"Nenhum dado encontrado para o Id {id}");
            return entity;
        }
    }
}
