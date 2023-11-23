using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("cliente");

            builder.HasIndex(e => e.IdDireccionFk, "idDireccionFk");

            builder.HasIndex(e => e.IdEmpleadoRepresentanteVentasFk, "idEmpleadoRepresentanteVentasFk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.ApellidoContacto)
                .HasMaxLength(255)
                .HasColumnName("apellidoContacto");
            builder.Property(e => e.Fax)
                .HasMaxLength(20)
                .HasColumnName("fax");
            builder.Property(e => e.IdDireccionFk).HasColumnName("idDireccionFk");
            builder.Property(e => e.IdEmpleadoRepresentanteVentasFk).HasColumnName("idEmpleadoRepresentanteVentasFk");
            builder.Property(e => e.LimiteCredito)
                .HasPrecision(10, 2)
                .HasColumnName("limiteCredito");
            builder.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            builder.Property(e => e.NombreContacto)
                .HasMaxLength(255)
                .HasColumnName("nombreContacto");
            builder.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");

            builder.HasOne(d => d.IdDireccionFkNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdDireccionFk)
                .HasConstraintName("cliente_ibfk_2");

            builder.HasOne(d => d.IdEmpleadoRepresentanteVentasFkNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdEmpleadoRepresentanteVentasFk)
                .HasConstraintName("cliente_ibfk_1");
        }
    }
}