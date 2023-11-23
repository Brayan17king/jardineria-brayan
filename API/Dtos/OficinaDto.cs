using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class OficinaDto : BaseDtoString
    {
        public string Telefono { get; set; }

        public int? IdDireccionFk { get; set; }
    }
}