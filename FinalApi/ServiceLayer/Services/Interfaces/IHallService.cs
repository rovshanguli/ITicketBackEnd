using ServiceLayer.DTOs.Hall;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IHallService
    {
        Task CreateAsync(HallDto hallDto);
        Task<List<HallDto>> GetAllAsync();
        Task UpdateAsync(int id, HallEditDto hall);
        Task<HallDto> GetAsync(int id);
        Task DeleteAsync(int id);
    }
}
