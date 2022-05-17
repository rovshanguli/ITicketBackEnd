using ServiceLayer.DTOs.Seans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ISeansService
    {
        Task CreateAsync(SeansDto seansDto);

        Task UpdateAsync(int id, SeansEditDto seans);
        Task DeleteAsync(int id);
        Task<List<SeansDto>> GetAllAsync();
    }
}
