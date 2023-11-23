using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DetallepedidoDto : BaseDtoInt
    {
        public int? Cantidad { get; set; }

        public decimal? PrecioUnidad { get; set; }

        public int? NumeroLinea { get; set; }

        public int? IdPedidoFk { get; set; }

        public string IdProductoFk { get; set; }
    }
}