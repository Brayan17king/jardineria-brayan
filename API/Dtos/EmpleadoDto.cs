using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmpleadoDto : BaseDtoInt
    {
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; }

        public string Email { get; set; }

        public int? IdDireccionFk { get; set; }

        public int? IdPuestoFk { get; set; }

        public int IdJefeFk { get; set; }

        public string IdOficinaFk { get; set; }
    }
}