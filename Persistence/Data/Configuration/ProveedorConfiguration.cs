using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Data.Configuration
{
    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("proveedor");

            builder.HasIndex(e => e.IdCiudadFk, "idCiudadFk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdCiudadFk).HasColumnName("idCiudadFk");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            builder.HasOne(d => d.IdCiudadFkNavigation).WithMany(p => p.Proveedores)
                .HasForeignKey(d => d.IdCiudadFk)
                .HasConstraintName("proveedor_ibfk_1");
        }
    }
}