using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Region : BaseEntityInt
{
    public string Nombre { get; set; } = null!;

    public int IdPaisFk { get; set; }

    public virtual ICollection<Ciudad> Ciudades { get; set; } = new List<Ciudad>();

    public virtual Pais IdPaisFkNavigation { get; set; } = null!;
}
