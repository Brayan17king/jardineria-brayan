using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DtosSec
{
    public class PedidoIdClienteIdFechaEntregaDto
    {
        public int Id { get; set; }
        public int IdClienteFk { get; set; }
        public DateOnly FechaEsperada { get; set; }
        public DateOnly FechaEntrega { get; set; }
    }
}