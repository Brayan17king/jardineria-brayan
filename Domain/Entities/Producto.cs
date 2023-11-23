using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Producto : BaseEntityString
{
    public string Nombre { get; set; }

    public string Dimensiones { get; set; }

    public decimal PrecioVenta { get; set; }

    public int? Cantidad { get; set; }

    public int? CantidadMin { get; set; }

    public int? CantidadMax { get; set; }

    public string IdGamaProductoFk { get; set; }

    public virtual ICollection<Detallepedido> Detallepedidos { get; set; } = new List<Detallepedido>();

    public virtual Gamaproducto IdGamaProductoFkNavigation { get; set; }

    public virtual ICollection<Productoproveedor> Productoproveedores { get; set; } = new List<Productoproveedor>();
}
