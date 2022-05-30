using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Event;
using ServiceLayer.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;
        public EventService(IEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(EventCreateDto eventCreateDto)
        {
            var model = _mapper.Map<Event>(eventCreateDto);
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var levent = await _repository.GetAsync(id);
            await _repository.DeleteAsync(levent);
        }

        public async Task<List<EventDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<EventDto>>(model);
            return res;
        }

        public async Task<EventDto> GetByIdAsync(int id)
        {
            var model = await _repository.GetEventAsync(id);
            var res = _mapper.Map<EventDto>(model);
            return res;
        }

        public async Task UpdateAsync(int id, EventEditDto levent)
        {
            var entity = await _repository.GetEventAsync(id);

            _mapper.Map(levent, entity);

            await _repository.UpdateAsync(entity);
        }

        public async Task<EventDto> GetAsync(int id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<EventDto>(model);
            return res;
        }
    }
}
