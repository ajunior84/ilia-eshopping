using IliaEShopping.Application.Models.Order;
using IliaEShopping.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace IliaEShopping.Application.Controllers
{
    /// <summary>
    /// Order API
    /// </summary>
    [Route("v1/order")]
    public class OrderController : BaseController
    {
        #region "  Variables  "

        private readonly IOrderService _orderService;

        #endregion

        #region "  Constructors  "

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #endregion

        #region "  Endpoints  "

        /// <summary>
        /// Creates new order for existing customer
        /// </summary>
        /// <param name="request">Order data</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Domain.Entities.Order), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody, Required] CreateOrderRequest request)
        {
            try
            {
                var result = await _orderService.AddAsync(request);
                return Ok(result);
            }
            catch (Infrastructure.CrossCutting.Exceptions.ValidationException ex)
            {
                return BadRequest(ex.Message, ex.ExtraInfo);
            }
        }

        /// <summary>
        /// Updates order statuses
        /// </summary>
        /// <param name="id">Order identifier</param>
        /// <param name="request">Status data</param>
        /// <returns></returns>
        [HttpPatch("{id}/status")]
        [ProducesResponseType(typeof(Domain.Entities.Order), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateStatus([FromRoute, Required] int id, [FromBody, Required] UpdateOrderStatusRequest request)
        {
            try
            {
                var result = await _orderService.UpdateStatusAsync(id, (short)request.OrderStatus);
                return Ok(result);
            }
            catch (Infrastructure.CrossCutting.Exceptions.ValidationException ex)
            {
                return BadRequest(ex.Message, ex.ExtraInfo);
            }
        }

        #endregion
    }
}
