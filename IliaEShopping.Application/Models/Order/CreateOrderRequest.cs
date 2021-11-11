using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IliaEShopping.Application.Models.Order
{
    /// <summary>
    /// Creae order request
    /// </summary>
    public class CreateOrderRequest
    {
        /// <summary>
        /// Order price
        /// </summary>
        [Required]
        [Range(0.01, double.MaxValue)]
        public double Price { get; set; }

        /// <summary>
        /// Customer identifier (usually automatically retrieved by JWT token)
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int CustomerId { get; set; }
    }
}
