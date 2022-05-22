using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Event> entities;

        public EventRepository(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<Event>();
        }

        public async Task<Event> GetEventAsync(int id)
        {
            var entity = await entities.Include(m => m.Category).Include(m => m.Hall).FirstOrDefaultAsync(m => m.Id == id);

            if (entity is null) throw new NullReferenceException();

            return entity;
        }
    }
}
