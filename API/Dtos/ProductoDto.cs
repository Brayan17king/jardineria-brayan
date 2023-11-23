using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductoDto : BaseDtoString
    {
        public string Nombre { get; set; }

        public string Dimensiones { get; set; }

        public decimal? PrecioVenta { get; set; }

        public int? Cantidad { get; set; }

        public int? CantidadMin { get; set; }

        public int? CantidadMax { get; set; }

        public string IdGamaProductoFk { get; set; }
    }
}