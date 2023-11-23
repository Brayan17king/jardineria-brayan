using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPedido : IGenericRepositoryInt<Pedido>
    {
        Task<IEnumerable<Pedido>> GetPedidosTardeAsync();
    }
}