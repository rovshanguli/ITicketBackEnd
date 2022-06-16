using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Slider;
using ServiceLayer.Services.Interfaces;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] SliderDto sliderDto)
        {
            await _service.CreateAsync(sliderDto);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
        [HttpPut]
        [Route("Update/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SliderEditDto slider)
        {


            await _service.UpdateAsync(id, slider);
            return Ok();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _service.GetAsync(id);
            return Ok(result);
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
