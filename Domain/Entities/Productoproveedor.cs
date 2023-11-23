using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Productoproveedor
{
    public int IdProveedorFk { get; set; }

    public string IdProductoFk { get; set; } = null!;

    public decimal? PrecioProveedor { get; set; }

    public virtual Producto IdProductoFkNavigation { get; set; } = null!;

    public virtual Proveedor IdProveedorFkNavigation { get; set; } = null!;
}
