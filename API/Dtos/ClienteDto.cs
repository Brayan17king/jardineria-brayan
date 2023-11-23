using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteDto : BaseDtoInt
    {
        public string Nombre { get; set; } = null!;

        public string NombreContacto { get; set; }

        public string ApellidoContacto { get; set; }

        public string Telefono { get; set; }

        public string Fax { get; set; }

        public decimal? LimiteCredito { get; set; }

        public int? IdEmpleadoRepresentanteVentasFk { get; set; }

        public int? IdDireccionFk { get; set; }
    }
}