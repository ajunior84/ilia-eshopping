using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Domain.Entities
{
    /// <summary>
    /// Order Status
    /// </summary>
    public class OrderStatus : BaseEntity
    {
        #region "  Constructors  "

        public OrderStatus()
        {
            OrderStatusHistory = new HashSet<OrderStatusHistory>();
            Orders = new HashSet<Order>();
        }

        #endregion

        #region " Properties  "

        /// <summary>
        /// Status identifier
        /// </summary>
        public new short Id { get; set; }

        /// <summary>
        /// Status Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// History
        /// </summary>
        public virtual ICollection<OrderStatusHistory> OrderStatusHistory { get; set; }

        /// <summary>
        /// Orders
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }

        #endregion
    }
}
