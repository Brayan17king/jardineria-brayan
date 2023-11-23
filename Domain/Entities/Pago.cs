using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Pago : BaseEntityString
{
    public DateOnly FechaPago { get; set; }

    public decimal Total { get; set; }

    public int IdClienteFk { get; set; }

    public int IdFormaPagoFk { get; set; }

    public virtual Cliente IdClienteFkNavigation { get; set; }

    public virtual Formapago IdFormaPagoFkNavigation { get; set; }
}
