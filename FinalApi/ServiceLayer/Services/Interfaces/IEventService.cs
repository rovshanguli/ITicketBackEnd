using ServiceLayer.DTOs.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IEventService
    {
        Task CreateAsync(EventDto eventDto);

        Task UpdateAsync(int id, EventEditDto levent);
        Task DeleteAsync(int id);
        Task<List<EventDto>> GetAllAsync();
        Task<EventDto> GetByIdAsync(int id);
    }
}
