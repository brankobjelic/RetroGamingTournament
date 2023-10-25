using RetroGamingTournament.Models;

namespace RetroGamingTournament.Repositories
{
    public interface IEventRepository
    {
        public Task<Event> Create(Event event);
        public Task<IEnumerable<Event>> GetAll();
        public Task<Event> Get(int id);
        public Task Delete(Event event);
    }
}
