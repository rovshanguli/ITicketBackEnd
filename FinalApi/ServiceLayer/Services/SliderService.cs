using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Slider;
using ServiceLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _repository;
        private readonly IMapper _mapper;
        public SliderService(ISliderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(SliderDto sliderDto)
        {
            var model = _mapper.Map<Slider>(sliderDto);
            await _repository.CreateAsync(model);

        }

        public async Task DeleteAsync(int id)
        {
            var slide = await _repository.GetAsync(id);
            await _repository.DeleteAsync(slide);
        }

        public async Task<List<SliderDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<SliderDto>>(model);
            return res;
        }

        public async Task UpdateAsync(int id, SliderEditDto slider)
        {
            var entity = await _repository.GetAsync(id);

            _mapper.Map(slider, entity);

            await _repository.UpdateAsync(entity);
        }
        public async Task<SliderDto> GetAsync(int id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<SliderDto>(model);
            return res;
        }
    }
}
