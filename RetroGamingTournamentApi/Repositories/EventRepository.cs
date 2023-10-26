using Microsoft.EntityFrameworkCore;
using RetroGamingTournament.Models;

namespace RetroGamingTournament.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Event> _collection;
        public EventRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
            _collection = appDbContext.Events;
        }
        public async Task<bool> CheckNameExists(string name)
        {
            bool eventNameExists = await _collection.AsNoTracking().AnyAsync(e => e.Name == name);
            return eventNameExists;
        }

        public Task<Event> Create(Event ev)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Event ev)
        {
            throw new NotImplementedException();
        }

        public Task<Event> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Event ev)
        {
            throw new NotImplementedException();
        }
    }
}
