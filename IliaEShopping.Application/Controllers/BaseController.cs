using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IliaEShopping.Application.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult BadRequest(string message, object extraInfo)
        {
            return BadRequest(new
            {
                Message = message,
                Data = extraInfo
            });
        }
    }
}
