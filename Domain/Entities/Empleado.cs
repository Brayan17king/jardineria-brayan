using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Empleado : BaseEntityInt
{
    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; }

    public string Email { get; set; }

    public int IdDireccionFk { get; set; }

    public int IdPuestoFk { get; set; }

    public int IdJefeFk { get; set; }

    public string IdOficinaFk { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Direccion IdDireccionFkNavigation { get; set; }

    public virtual Puesto IdPuestoFkNavigation { get; set; }

    public Empleado IdJefeFkNavigation { get; set; }

    public Oficina IdOficinaFkNavigation { get; set; }
}
