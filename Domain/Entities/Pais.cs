using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Pais : BaseEntityInt
{
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Region> Regiones { get; set; } = new List<Region>();
}
