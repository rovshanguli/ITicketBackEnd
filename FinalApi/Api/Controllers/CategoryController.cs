using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Category;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult> Create([FromBody] CategoryDto categoryDto)
        {
            await _service.CreateAsync(categoryDto);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateCategory/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryEditDto category)
        {


            await _service.UpdateAsync(id, category);
            return Ok();

        }
        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }
    }
}
