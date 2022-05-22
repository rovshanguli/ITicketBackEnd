using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Seans;
using ServiceLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class SeansService : ISeansService
    {
        private readonly ISeansRepository _repository;
        private readonly IMapper _mapper;
        public SeansService(ISeansRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(SeansDto seansDto)
        {
            var model = _mapper.Map<Seans>(seansDto);
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var seans = await _repository.GetAsync(id);
            await _repository.DeleteAsync(seans);
        }

        public async Task<List<SeansDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<SeansDto>>(model);
            return res;
        }

        public async Task UpdateAsync(int id, SeansEditDto seans)
        {
            var entity = await _repository.GetAsync(id);

            _mapper.Map(seans, entity);

            await _repository.UpdateAsync(entity);
        }
    }
}
