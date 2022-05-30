using ServiceLayer.DTOs.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryDto categoryDto);

        Task UpdateAsync(CategoryEditDto category);
        Task DeleteAsync(int id);
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetAsync(int id);
    }
}
