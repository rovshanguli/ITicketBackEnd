using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Hall;
using ServiceLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class HallService : IHallService
    {

        private readonly IHallRepository _repository;
        private readonly IMapper _mapper;
        public HallService(IHallRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task CreateAsync(HallDto hallDto)
        {
            var model = _mapper.Map<Hall>(hallDto);
            await _repository.CreateAsync(model);

        }

        public async Task DeleteAsync(int id)
        {
            var hall = await _repository.GetAsync(id);
            await _repository.DeleteAsync(hall);
        }

        public async Task<List<HallDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<HallDto>>(model);
            return res;
        }

        public async Task UpdateAsync(int id, HallEditDto hall)
        {
            var entity = await _repository.GetAsync(id);

            _mapper.Map(hall, entity);

            await _repository.UpdateAsync(entity);
        }
    }
}
