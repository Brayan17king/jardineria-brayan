using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Oficina : BaseEntityString
{
    public string Telefono { get; set; }

    public int IdDireccionFk { get; set; }

    public virtual Direccion IdDireccionFkNavigation { get; set; }
}
