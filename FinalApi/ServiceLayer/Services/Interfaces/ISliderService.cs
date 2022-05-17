using ServiceLayer.DTOs.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ISliderService
    {
        Task CreateAsync(SliderDto sliderDto);
        Task<List<SliderDto>> GetAllAsync();
        Task UpdateAsync(int id, SliderEditDto slider);
        Task DeleteAsync(int id);
    }
}
