using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("ciudad");

            builder.HasIndex(e => e.IdRegionFk, "idRegionFk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdRegionFk).HasColumnName("idRegionFk");
            builder.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");

            builder.HasOne(d => d.IdRegionFkNavigation).WithMany(p => p.Ciudades)
                .HasForeignKey(d => d.IdRegionFk)
                .HasConstraintName("ciudad_ibfk_1");
        }
    }
}