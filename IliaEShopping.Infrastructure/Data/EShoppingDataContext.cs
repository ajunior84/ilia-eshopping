﻿using IliaEShopping.Domain.Entities;
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
        #region "  Constructors  "

        public EShoppingDataContext() { }

        public EShoppingDataContext(DbContextOptions<EShoppingDataContext> options) : base(options) { }

        #endregion

        #region "  DB Sets  "

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<OrderStatusHistory> OrderStatusHistory { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new OrderStatusMap());
            modelBuilder.ApplyConfiguration(new OrderStatusHistoryMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
        }
    }
}
