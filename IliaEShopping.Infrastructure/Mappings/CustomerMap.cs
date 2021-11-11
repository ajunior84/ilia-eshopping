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
    public class CustomerMap : IEntityTypeConfiguration<Domain.Entities.Customer>
    {
        #region "  Public Methods "

        public void Configure(EntityTypeBuilder<Domain.Entities.Customer> entity)
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Id).HasColumnType("int(11)");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasColumnType("varchar(50)");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");
        }

        #endregion
    }
}
