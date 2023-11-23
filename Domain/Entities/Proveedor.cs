using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Proveedor : BaseEntityInt
{
    public string Nombre { get; set; } = null!;

    public int? IdCiudadFk { get; set; }

    public virtual Ciudad IdCiudadFkNavigation { get; set; }

    public virtual ICollection<Productoproveedor> Productoproveedores { get; set; } = new List<Productoproveedor>();
}
