using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Infrastructure.Mappings
{
    /// <summary>
    /// Order Status History fields database map
    /// </summary>
    public class OrderStatusHistoryMap : IEntityTypeConfiguration<Domain.Entities.OrderStatusHistory>
    {
        #region "  Public Methods "

        public void Configure(EntityTypeBuilder<Domain.Entities.OrderStatusHistory> entity)
        {
            entity.ToTable("OrderStatusHistory");

            entity.HasIndex(e => e.OrderId)
                    .HasName("FK_ORDER_ORDERSTATUSHISTORY");

            entity.HasIndex(e => e.OrderStatusId)
                .HasName("FK_ORDERSTATUS_ORDERSTATUSHISTORY");

            entity.Property(e => e.Id).HasColumnType("int(11)");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.Property(e => e.OrderId).HasColumnType("int(11)");

            entity.Property(e => e.OrderStatusId).HasColumnType("smallint(6)");

            entity.HasOne(d => d.Order)
                .WithMany(p => p.OrderStatusHistory)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_ORDERSTATUSHISTORY");

            entity.HasOne(d => d.OrderStatus)
                .WithMany(p => p.OrderStatusHistory)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDERSTATUS_ORDERSTATUSHISTORY");
        }

        #endregion
    }
}
