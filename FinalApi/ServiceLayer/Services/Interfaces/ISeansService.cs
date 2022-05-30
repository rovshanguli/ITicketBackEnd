using ServiceLayer.DTOs.Seans;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ISeansService
    {
        Task CreateAsync(SeansDto seansDto);

        Task UpdateAsync(int id, SeansEditDto seans);
        Task<SeansDto> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<List<SeansDto>> GetAllAsync();
    }
}
