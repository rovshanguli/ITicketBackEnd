using ServiceLayer.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(OrderDto orderDto);
        Task<List<OrderDto>> GetAllAsync(int id);
        Task Delete(OrderDto orderDto);
    }
}
