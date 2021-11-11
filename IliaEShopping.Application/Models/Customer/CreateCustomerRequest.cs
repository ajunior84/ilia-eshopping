using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IliaEShopping.Application.Models.Customer
{
    /// <summary>
    /// Create customer request
    /// </summary>
    public class CreateCustomerRequest
    {
        /// <summary>
        /// Customer name
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Customer e-mail
        /// </summary>
        [EmailAddress]
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
