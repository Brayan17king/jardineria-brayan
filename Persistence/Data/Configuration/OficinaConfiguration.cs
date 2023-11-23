using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class OficinaConfiguration : IEntityTypeConfiguration<Oficina>
    {
        public void Configure(EntityTypeBuilder<Oficina> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("oficina");

            builder.HasIndex(e => e.IdDireccionFk, "idDireccionFk");

            builder.Property(e => e.Id)
                .HasMaxLength(10)
                .HasColumnName("id");
            builder.Property(e => e.IdDireccionFk).HasColumnName("idDireccionFk");
            builder.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");

            builder.HasOne(d => d.IdDireccionFkNavigation).WithOne(p => p.IdOficinaFkNavigation)
                .HasForeignKey<Oficina>(d => d.IdDireccionFk)
                .HasConstraintName("oficina_ibfk_1");
        }
    }
}