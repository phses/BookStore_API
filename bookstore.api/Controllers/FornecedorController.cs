using AutoMapper;
using bookstore.Domain.Contracts.Request;
using bookstore.Domain.Contracts.Response;
using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
    public class FornecedorController : BaseController<Fornecedor, FornecedorRequest, FornecedorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFornecedorService _fornecedorService;
        public FornecedorController(IMapper mapper, INotificador notificador, IFornecedorService fornecedorService) : base(mapper, notificador, fornecedorService)
        {
            _mapper = mapper;
            _fornecedorService = fornecedorService;
        }
    }
}
