using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Estado : BaseEntityInt
{
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
