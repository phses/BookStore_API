using AutoMapper;
using bookstore.Domain.Contracts.Request;
using bookstore.Domain.Contracts.Response;
using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
    public class LivroController : BaseController<Livro, LivroRequest, LivroResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILivroService _livroService;
        public LivroController(IMapper mapper, INotificador notificador, ILivroService livroService) : base(mapper, notificador, livroService)
        {
            _mapper = mapper;
            _livroService = livroService;
        }
    }
}
