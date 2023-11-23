using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Data.Configuration
{
    public class ProductoproveedorConfiguration : IEntityTypeConfiguration<Productoproveedor>
    {
        public void Configure(EntityTypeBuilder<Productoproveedor> builder)
        {
            builder.HasKey(e => new { e.IdProveedorFk, e.IdProductoFk })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            builder.ToTable("productoproveedor");

            builder.HasIndex(e => e.IdProductoFk, "idProductoFk");

            builder.Property(e => e.IdProveedorFk).HasColumnName("idProveedorFk");
            builder.Property(e => e.IdProductoFk).HasColumnName("idProductoFk");
            builder.Property(e => e.PrecioProveedor)
                .HasPrecision(10, 2)
                .HasColumnName("precio_proveedor");

            builder.HasOne(d => d.IdProductoFkNavigation).WithMany(p => p.Productoproveedores)
                .HasForeignKey(d => d.IdProductoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productoproveedor_ibfk_2");

            builder.HasOne(d => d.IdProveedorFkNavigation).WithMany(p => p.Productoproveedores)
                .HasForeignKey(d => d.IdProveedorFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productoproveedor_ibfk_1");
        }
    }
}