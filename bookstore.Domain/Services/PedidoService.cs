using bookstore.Domain.Entities;
using bookstore.Domain.Interfaces;
using bookstore.Domain.Interfaces.Repositories;
using bookstore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore.Domain.Services
{
    public class PedidoService : BaseService<Pedido>, IPedidoService
    {

        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository, INotificador notificador, IHttpContextAccessor httpContextAccessor) : base(pedidoRepository, notificador, httpContextAccessor)
        {
        }
    }
}
