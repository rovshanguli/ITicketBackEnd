using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Event;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService _service;
        public EventController(IEventService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateEvent")]
        public async Task<IActionResult> Create([FromBody] EventDto eventDto)
        {
            await _service.CreateAsync(eventDto);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteEvent")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateEvent/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EventEditDto levent)
        {


            await _service.UpdateAsync(id, levent);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllEvents")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

    }
}
