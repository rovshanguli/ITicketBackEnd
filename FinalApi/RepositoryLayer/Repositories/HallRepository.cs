using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;

namespace RepositoryLayer.Repositories
{
    public class HallRepository : Repository<Hall>, IHallRepository
    {
        public HallRepository(AppDbContext context) : base(context)
        {

        }
    }
}
