using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("direccion");

            builder.HasIndex(e => e.IdCiudadFk, "idCiudadFk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Bis)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("bis");
            builder.Property(e => e.CardinalPrimario)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cardinalPrimario");
            builder.Property(e => e.CardinalSecundario)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cardinalSecundario");
            builder.Property(e => e.CodigoPostal)
                .HasMaxLength(10)
                .HasColumnName("codigoPostal");
            builder.Property(e => e.Complemento)
                .HasMaxLength(50)
                .HasColumnName("complemento");
            builder.Property(e => e.IdCiudadFk).HasColumnName("idCiudadFk");
            builder.Property(e => e.LetraPrincipal)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letraPrincipal");
            builder.Property(e => e.LetraSecundaria)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letraSecundaria");
            builder.Property(e => e.LetraTerciaria)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letraTerciaria");
            builder.Property(e => e.NumeroPrincipal).HasColumnName("numeroPrincipal");
            builder.Property(e => e.NumeroSecundario).HasColumnName("numeroSecundario");
            builder.Property(e => e.NumeroTerciario).HasColumnName("numeroTerciario");
            builder.Property(e => e.TipoVia)
                .HasMaxLength(50)
                .HasColumnName("tipoVia");

            builder.HasOne(d => d.IdCiudadFkNavigation).WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.IdCiudadFk)
                .HasConstraintName("direccion_ibfk_1");
        }
    }
}