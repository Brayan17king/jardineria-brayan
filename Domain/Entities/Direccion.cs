using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Direccion : BaseEntityInt
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

    public int IdCiudadFk { get; set; }
    
    public string IdOficinaFk { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual Ciudad IdCiudadFkNavigation { get; set; }

    public virtual Oficina IdOficinaFkNavigation { get; set; }
}
