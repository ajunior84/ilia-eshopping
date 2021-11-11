using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Infrastructure.Mappings
{
    /// <summary>
    /// Customer fields database map
    /// </summary>
    public class OrderStatusMap : IEntityTypeConfiguration<Domain.Entities.OrderStatus>
    {
        #region "  Public Methods "

        public void Configure(EntityTypeBuilder<Domain.Entities.OrderStatus> entity)
        {
            entity.ToTable("OrderStatus");

            entity.Property(e => e.Id)
                    .HasColumnType("smallint(6)")
                    .ValueGeneratedNever();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_general_ci");
        }

        #endregion
    }
}
