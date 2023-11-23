using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Detallepedido : BaseEntityInt
{
    public int? Cantidad { get; set; }

    public decimal? PrecioUnidad { get; set; }

    public int? NumeroLinea { get; set; }

    public int? IdPedidoFk { get; set; }

    public string IdProductoFk { get; set; }

    public virtual Pedido IdPedidoFkNavigation { get; set; }

    public virtual Producto IdProductoFkNavigation { get; set; }
}
