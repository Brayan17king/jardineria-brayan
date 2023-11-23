using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Ciudad : BaseEntityInt
{
    public string Nombre { get; set; } = null!;

    public int? IdRegionFk { get; set; }

    public virtual ICollection<Direccion> Direcciones { get; set; } = new List<Direccion>();

    public virtual Region IdRegionFkNavigation { get; set; }

    public virtual ICollection<Proveedor> Proveedores { get; set; } = new List<Proveedor>();
}
