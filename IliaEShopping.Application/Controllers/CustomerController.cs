using IliaEShopping.Application.Models.Customer;
using IliaEShopping.Domain.Entities;
using IliaEShopping.Service.Interfaces;
using IliaEShopping.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace IliaEShopping.Application.Controllers
{
    /// <summary>
    /// Customer API
    /// </summary>
    public class CustomerController : BaseController
    {
        #region "  Variables  "

        private readonly ICustomerService _customerService;

        #endregion

        #region "  Constructors  "

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        #endregion

        #region "  Endpoints  "

        /// <summary>
        /// Creates a new Customer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody, Required] CreateCustomerRequest request)
        {
            var result = await _customerService.AddAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// Returns a list of all Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Customer>), StatusCodes.Status200OK)]
        public async Task<IActionResult> List()
        {
            var list = await _customerService.ListAsync();
            return Ok(list);
        }

        /// <summary>
        /// Returns a Customer by id
        /// </summary>
        /// <param name="id">Customer id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute, Required] int id)
        {
            var customer = await _customerService.GetWithOdersAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        #endregion
    }
}
