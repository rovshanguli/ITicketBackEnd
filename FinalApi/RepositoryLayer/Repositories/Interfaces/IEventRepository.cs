using DomainLayer.Entities;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<Event> GetEventAsync(int id);
    }
}
