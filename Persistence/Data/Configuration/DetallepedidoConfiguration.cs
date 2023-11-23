using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Data.Configuration
{
    public class DetallepedidoConfiguration : IEntityTypeConfiguration<Detallepedido>
    {
        public void Configure(EntityTypeBuilder<Detallepedido> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("detallepedido");

            builder.HasIndex(e => e.IdPedidoFk, "idPedidoFk");

            builder.HasIndex(e => e.IdProductoFk, "idProductoFk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Cantidad).HasColumnName("cantidad");
            builder.Property(e => e.IdPedidoFk).HasColumnName("idPedidoFk");
            builder.Property(e => e.IdProductoFk)
                .HasMaxLength(15)
                .HasColumnName("idProductoFk");
            builder.Property(e => e.NumeroLinea).HasColumnName("numeroLinea");
            builder.Property(e => e.PrecioUnidad)
                .HasPrecision(10, 2)
                .HasColumnName("precioUnidad");

            builder.HasOne(d => d.IdPedidoFkNavigation).WithMany(p => p.Detallepedidos)
                .HasForeignKey(d => d.IdPedidoFk)
                .HasConstraintName("detallepedido_ibfk_1");

            builder.HasOne(d => d.IdProductoFkNavigation).WithMany(p => p.Detallepedidos)
                .HasForeignKey(d => d.IdProductoFk)
                .HasConstraintName("detallepedido_ibfk_2");
        }
    }
}