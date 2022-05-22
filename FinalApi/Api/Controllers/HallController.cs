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
        public async Task<IActionResult> Create([FromBody] HallDto hallDto)
        {
            await _service.CreateAsync(hallDto);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteHall")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateHall/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] HallEditDto hall)
        {


            await _service.UpdateAsync(id, hall);
            return Ok();
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
