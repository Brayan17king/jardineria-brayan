using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("empleado");

            builder.HasIndex(e => e.IdDireccionFk, "idDireccionFk");

            builder.HasIndex(e => e.IdPuestoFk, "idPuestoFk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Apellido)
                .HasMaxLength(255)
                .HasColumnName("apellido");
            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            builder.Property(e => e.IdDireccionFk).HasColumnName("idDireccionFk");
            builder.Property(e => e.IdPuestoFk).HasColumnName("idPuestoFk");
            builder.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");

            builder.HasOne(d => d.IdDireccionFkNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdDireccionFk)
                .HasConstraintName("empleado_ibfk_1");

            builder.HasOne(d => d.IdPuestoFkNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdPuestoFk)
                .HasConstraintName("empleado_ibfk_2");
        }
    }
}