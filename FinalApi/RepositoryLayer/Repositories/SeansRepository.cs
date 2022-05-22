using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;

namespace RepositoryLayer.Repositories
{
    public class SeansRepository : Repository<Seans>, ISeansRepository
    {
        public SeansRepository(AppDbContext context) : base(context)
        {

        }

    }
}
