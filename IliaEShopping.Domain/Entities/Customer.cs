using System;
using System.Collections.Generic;
using System.Text;

namespace IliaEShopping.Domain.Entities
{
    /// <summary>
    /// Customer
    /// </summary>
    public class Customer : BaseEntity
    {
        #region "  Constructors  "

        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        #endregion

        #region "  Properties  "

        /// <summary>
        /// Customer Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Customer E-mail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        public virtual DateTime CreatedAt { get; set; }

        /// <summary>
        /// Orders
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }

        #endregion
    }
}
