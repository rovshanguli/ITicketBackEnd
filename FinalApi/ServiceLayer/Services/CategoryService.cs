using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Category;
using ServiceLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CategoryDto categoryDto)
        {
            var model = _mapper.Map<Category>(categoryDto);
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _repository.GetAsync(id);
            await _repository.DeleteAsync(category);
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<CategoryDto>>(model);
            return res;
        }

        public async Task<CategoryDto> GetAsync(int id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<CategoryDto>(model);
            return res;
        }

        public async Task UpdateAsync(CategoryEditDto category)
        {
            var entity = await _repository.GetAsync(category.Id);

            _mapper.Map(category, entity);

            await _repository.UpdateAsync(entity);
        }
    }
}
