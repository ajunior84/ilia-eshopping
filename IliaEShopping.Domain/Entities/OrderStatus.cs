using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Domain.Entities
{
    public class OrderStatus : BaseEntity
    {
        public OrderStatus()
        {
            OrderStatusHistory = new HashSet<OrderStatusHistory>();
            Orders = new HashSet<Order>();
        }

        public string Name { get; set; }

        public virtual ICollection<OrderStatusHistory> OrderStatusHistory { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
