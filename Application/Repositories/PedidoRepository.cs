using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repositories
{
    public class PedidoRepository : GenericRepositoryInt<Pedido>, IPedido
    {
        private readonly GardensContext _context;

        public PedidoRepository(GardensContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pedido>> GetPedidosTardeAsync() // 2611
        {
            return await _context.Pedidos
                        .Where(x => x.FechaEntrega > x.FechaEsperada)
                        .ToListAsync();
        }
    }
}