using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Order;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> Create([FromBody] OrderDto orderDto)
        {
            await _service.CreateAsync(orderDto);
            return Ok();
        }
    }
}
