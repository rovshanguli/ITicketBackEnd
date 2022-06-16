using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Hall;
using ServiceLayer.Services.Interfaces;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class HallController : BaseController
    {
        private readonly IHallService _service;
        public HallController(IHallService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateHall")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] HallDto hallDto)
        {
            await _service.CreateAsync(hallDto);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteHall/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateHall/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] HallEditDto hall)
        {


            await _service.UpdateAsync(id, hall);
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
        [Route("GetAllHalls")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

    }
}
