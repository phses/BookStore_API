using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace bookstore.Domain.Services
{
    public class PerfilService : BaseService<Perfil>, IPerfilService
    {
        public PerfilService(IPerfilRepository perfilRepository, INotificador notificador, IHttpContextAccessor httpContextAccessor) : base(perfilRepository, notificador, httpContextAccessor)
        {
        }
    }
}
