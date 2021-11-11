using IliaEShopping.Domain.ObjectValues;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IliaEShopping.Application.Models.Order
{
    /// <summary>
    /// Udpates order status
    /// </summary>
    public class UpdateOrderStatusRequest
    {
        /// <summary>
        /// New status identifier
        /// </summary>
        [Required]
        public OrderStatusType OrderStatus { get; set; }
    }
}
