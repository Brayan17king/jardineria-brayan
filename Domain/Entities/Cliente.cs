using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Cliente : BaseEntityInt
{
    public string Nombre { get; set; } = null!;

    public string NombreContacto { get; set; }

    public string ApellidoContacto { get; set; }

    public string Telefono { get; set; }

    public string Fax { get; set; }

    public decimal LimiteCredito { get; set; }

    public int IdEmpleadoRepresentanteVentasFk { get; set; }

    public int IdDireccionFk { get; set; }

    public virtual Direccion IdDireccionFkNavigation { get; set; }

    public virtual Empleado IdEmpleadoRepresentanteVentasFkNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
