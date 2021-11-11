using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Domain.Entities
{
    /// <summary>
    /// Order Status History
    /// </summary>
    public partial class OrderStatusHistory : BaseEntity
    {
        #region "  Properties  "

        /// <summary>
        /// Order identifier
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Order Status identifier
        /// </summary>
        public short OrderStatusId { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Order
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Order Status
        /// </summary>
        public virtual OrderStatus OrderStatus { get; set; }

        #endregion
    }
}
