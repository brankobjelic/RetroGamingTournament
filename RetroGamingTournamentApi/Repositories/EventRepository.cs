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

        public async Task<Event> Create(Event ev)
        {
            var returnedValue = await _context.AddAsync(ev);
            _context.SaveChanges();
            return ev; //or returnedValue?
        }

        public Task Delete(Event ev)
        {
            throw new NotImplementedException();
        }

        public async Task<Event> Get(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            var events = await _collection.AsNoTracking().ToListAsync();
            return events;
        }

        public Task Update(Event ev)
        {
            throw new NotImplementedException();
        }

        public async Task<Event> GetActive()
        {
            var activeEvent = await _collection.Where(e => e.IsActive).FirstAsync();
            return activeEvent;
        }
    }
}
