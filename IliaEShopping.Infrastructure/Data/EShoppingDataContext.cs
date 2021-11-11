using IliaEShopping.Domain.Entities;
using IliaEShopping.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Infrastructure.Data
{
    /// <summary>
    /// EShoppingDataContext Database Context
    /// </summary>
    public class EShoppingDataContext : DbContext
    {
        public EShoppingDataContext(DbContextOptions<EShoppingDataContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(new CustomerMap().Configure);
        }
    }
}
