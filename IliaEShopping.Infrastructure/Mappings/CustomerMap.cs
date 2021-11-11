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

        public void Configure(EntityTypeBuilder<Domain.Entities.Customer> builder)
        {
            builder.ToTable("Customer");

            // Id
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            // Name
            builder.Property(p => p.Name)
                .HasConversion(p => p.ToString(), p => p)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(100)");

            // Email
            builder.Property(p => p.Email)
                .HasConversion(p => p.ToString(), p => p)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(50)");

            // CreatedAt
            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime");
        }

        #endregion
    }
}
