using ServiceLayer.DTOs.Slider;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ISliderService
    {
        Task CreateAsync(SliderDto sliderDto);
        Task<List<SliderDto>> GetAllAsync();
        Task UpdateAsync(int id, SliderEditDto slider);
        Task<SliderDto> GetAsync(int id);
        Task DeleteAsync(int id);
    }
}
