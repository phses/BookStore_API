using AutoMapper;
using bookstore.Domain.Contracts.Request;
using bookstore.Domain.Contracts.Response;
using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.api.Controllers
{
    public class PerfilController : BaseController<Perfil, PerfilRequest, PerfilResponse>
    {
        public PerfilController(IMapper mapper, 
                                INotificador notificador, 
                                IPerfilService perfilService) : base(mapper, notificador, perfilService)
        {
        }
    }
}
