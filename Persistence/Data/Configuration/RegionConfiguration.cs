using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("region");

            builder.HasIndex(e => e.IdPaisFk, "idPaisFk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdPaisFk).HasColumnName("idPaisFk");
            builder.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");

            builder.HasOne(d => d.IdPaisFkNavigation).WithMany(p => p.Regiones)
                .HasForeignKey(d => d.IdPaisFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("region_ibfk_1");
        }
    }
}