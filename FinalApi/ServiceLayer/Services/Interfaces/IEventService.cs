using ServiceLayer.DTOs.Event;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IEventService
    {
        Task CreateAsync(EventCreateDto eventCreateDto);

        Task UpdateAsync(int id, EventEditDto levent);
        Task DeleteAsync(int id);
        Task<List<EventDto>> GetAllAsync();
        Task<EventDto> GetAsync(int id);
        Task<EventDto> GetByIdAsync(int id);
    }
}
