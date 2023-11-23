using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class GamaproductoConfiguration : IEntityTypeConfiguration<Gamaproducto>
    {
        public void Configure(EntityTypeBuilder<Gamaproducto> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("gamaproducto");

            builder.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            builder.Property(e => e.DescripcionHtml)
                .HasColumnType("text")
                .HasColumnName("descripcionHtml");
            builder.Property(e => e.DescripcionTexto)
                .HasMaxLength(255)
                .HasColumnName("descripcionTexto");
            builder.Property(e => e.Imagen)
                .HasMaxLength(255)
                .HasColumnName("imagen");
        }
    }
}