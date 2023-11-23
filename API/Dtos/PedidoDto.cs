using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PedidoDto : BaseDtoInt
    {
        public DateOnly? FechaPedido { get; set; }

        public DateOnly? FechaEsperada { get; set; }

        public DateOnly? FechaEntrega { get; set; }

        public string Comentarios { get; set; }

        public int? IdClienteFk { get; set; }

        public int? IdEstadoFk { get; set; }
    }
}