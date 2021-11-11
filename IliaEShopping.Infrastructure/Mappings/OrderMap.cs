using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Infrastructure.Mappings
{
    /// <summary>
    /// Order fields database map
    /// </summary>
    public class OrderMap : IEntityTypeConfiguration<Domain.Entities.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Order> entity)
        {
            entity.ToTable("Orders");

            entity.HasIndex(e => e.CustomerId)
                    .HasName("FK_CUSTOMER_ORDER");

            entity.HasIndex(e => e.OrderStatusId)
                .HasName("FK_ORDERSTATUS_ORDER");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .ValueGeneratedNever();

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.Property(e => e.CustomerId).HasColumnType("int(11)");

            entity.Property(e => e.OrderStatusId).HasColumnType("smallint(6)");

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CUSTOMER_ORDER");

            entity.HasOne(d => d.OrderStatus)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDERSTATUS_ORDER");
        }
    }
}
