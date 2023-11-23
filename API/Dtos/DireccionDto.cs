using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DireccionDto : BaseDtoInt
    {
        public string TipoVia { get; set; }

        public short? NumeroPrincipal { get; set; }

        public string LetraPrincipal { get; set; }

        public string Bis { get; set; }

        public string LetraSecundaria { get; set; }

        public string CardinalPrimario { get; set; }

        public short? NumeroSecundario { get; set; }

        public string LetraTerciaria { get; set; }

        public short? NumeroTerciario { get; set; }

        public string CardinalSecundario { get; set; }

        public string Complemento { get; set; }

        public string CodigoPostal { get; set; }

        public int? IdCiudadFk { get; set; }
    }
}