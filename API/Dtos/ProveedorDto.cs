using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProveedorDto : BaseDtoInt
    {
        public string Nombre { get; set; } = null!;

        public int? IdCiudadFk { get; set; }
    }
}