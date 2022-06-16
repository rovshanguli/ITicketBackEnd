using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Category;
using ServiceLayer.Services.Interfaces;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("CreateCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CategoryDto categoryDto)
        {
            await _service.CreateAsync(categoryDto);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] CategoryEditDto category)
        {
            await _service.UpdateAsync(category);
            return Ok();
        }
        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var result = await _service.GetAsync(id);
            return Ok(result);
        }
    }
}
