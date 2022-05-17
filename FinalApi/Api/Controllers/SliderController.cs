using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Slider;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class SliderController : BaseController
    {
        private readonly ISliderService _service;
        public SliderController(ISliderService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] SliderDto sliderDto)
        {
            await _service.CreateAsync(sliderDto);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SliderEditDto slider)
        {


            await _service.UpdateAsync(id, slider);
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
    }
}
