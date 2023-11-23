using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("producto");

            builder.HasIndex(e => e.IdGamaProductoFk, "idGamaProductoFk");

            builder.Property(e => e.Id)
                .HasMaxLength(15)
                .HasColumnName("id");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.CantidadMax).HasColumnName("cantidadMax");
            builder.Property(e => e.CantidadMin).HasColumnName("cantidadMin");
            builder.Property(e => e.Dimensiones)
                .HasMaxLength(25)
                .HasColumnName("dimensiones");
            builder.Property(e => e.IdGamaProductoFk)
                .HasMaxLength(50)
                .HasColumnName("idGamaProductoFk");
            builder.Property(e => e.Nombre)
                .HasMaxLength(70)
                .HasColumnName("nombre");
            builder.Property(e => e.PrecioVenta)
                .HasPrecision(15, 2)
                .HasColumnName("precioVenta");

            builder.HasOne(d => d.IdGamaProductoFkNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdGamaProductoFk)
                .HasConstraintName("producto_ibfk_1");
        }
    }
}