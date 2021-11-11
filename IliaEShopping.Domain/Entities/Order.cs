using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderStatusHistory = new HashSet<OrderStatusHistory>();
        }

        public double Price { get; set; }
        public int CustomerId { get; set; }
        public short OrderStatusId { get; set; }
        public virtual DateTime CreatedAt { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderStatusHistory> OrderStatusHistory { get; set; }
    }
}
