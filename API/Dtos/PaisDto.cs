using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PaisDto : BaseDtoInt
    {
        public string Nombre { get; set; } = null!;
    }
}