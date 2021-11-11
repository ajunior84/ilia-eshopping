using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Domain.Entities
{
    /// <summary>
    /// Order
    /// </summary>
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderStatusHistory = new HashSet<OrderStatusHistory>();
        }

        /// <summary>
        /// Order Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Order Status identifier
        /// </summary>
        public short OrderStatusId { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        public virtual DateTime CreatedAt { get; set; }

        /// <summary>
        /// Customer
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Order Status
        /// </summary>
        public virtual OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// History
        /// </summary>
        public virtual ICollection<OrderStatusHistory> OrderStatusHistory { get; set; }
    }
}
