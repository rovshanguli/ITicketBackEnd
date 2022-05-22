using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Seans;
using ServiceLayer.Services.Interfaces;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class SeansController : BaseController
    {
        private readonly ISeansService _service;
        public SeansController(ISeansService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateSeans")]
        public async Task<IActionResult> Create([FromBody] SeansDto seansDto)
        {
            await _service.CreateAsync(seansDto);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteSeans")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateSeans/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SeansEditDto seans)
        {


            await _service.UpdateAsync(id, seans);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllSeans")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
    }
}
