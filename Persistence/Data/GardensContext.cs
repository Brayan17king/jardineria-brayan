using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Reflection;
namespace Persistence.Data;

public partial class GardensContext : DbContext
{
    public GardensContext()
    {
    }

    public GardensContext(DbContextOptions<GardensContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudad> Ciudades { get; set; }
    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Detallepedido> Detallepedidos { get; set; }
    public virtual DbSet<Direccion> Direcciones { get; set; }
    public virtual DbSet<Empleado> Empleados { get; set; }
    public virtual DbSet<Estado> Estados { get; set; }
    public virtual DbSet<Formapago> Formapagos { get; set; }
    public virtual DbSet<Gamaproducto> Gamaproductos { get; set; }
    public virtual DbSet<Oficina> Oficinas { get; set; }
    public virtual DbSet<Pago> Pagos { get; set; }
    public virtual DbSet<Pais> Paises { get; set; }
    public virtual DbSet<Pedido> Pedidos { get; set; }
    public virtual DbSet<Producto> Productos { get; set; }
    public virtual DbSet<Productoproveedor> Productoproveedores { get; set; }
    public virtual DbSet<Proveedor> Proveedores { get; set; }
    public virtual DbSet<Puesto> Puestos { get; set; }
    public virtual DbSet<Region> Regiones { get; set; }

    public DbSet<Rol> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRol> UserRoles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder) // 2611
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
