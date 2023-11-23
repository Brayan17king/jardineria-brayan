using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Data.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("pedido");

            builder.HasIndex(e => e.IdClienteFk, "idClienteFk");

            builder.HasIndex(e => e.IdEstadoFk, "idEstadoFk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Comentarios)
                .HasColumnType("text")
                .HasColumnName("comentarios");
            builder.Property(e => e.FechaEntrega).HasColumnName("fechaEntrega");
            builder.Property(e => e.FechaEsperada).HasColumnName("fechaEsperada");
            builder.Property(e => e.FechaPedido).HasColumnName("fechaPedido");
            builder.Property(e => e.IdClienteFk).HasColumnName("idClienteFk");
            builder.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFk");

            builder.HasOne(d => d.IdClienteFkNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdClienteFk)
                .HasConstraintName("pedido_ibfk_1");

            builder.HasOne(d => d.IdEstadoFkNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdEstadoFk)
                .HasConstraintName("pedido_ibfk_2");
        }
    }
}