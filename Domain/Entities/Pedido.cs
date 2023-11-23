using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Pedido : BaseEntityInt
{
    public DateOnly FechaPedido { get; set; }

    public DateOnly FechaEsperada { get; set; }

    public DateOnly? FechaEntrega { get; set; } = null;

    public string Comentarios { get; set; }

    public int IdClienteFk { get; set; }

    public int IdEstadoFk { get; set; }

    public virtual ICollection<Detallepedido> Detallepedidos { get; set; } = new List<Detallepedido>();

    public virtual Cliente IdClienteFkNavigation { get; set; }

    public virtual Estado IdEstadoFkNavigation { get; set; }
}
