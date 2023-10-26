using RetroGamingTournament.Models;

namespace RetroGamingTournament.Repositories
{
    public interface IEventRepository
    {
        public Task<Event> Create(Event ev);
        public Task<IEnumerable<Event>> GetAll();
        public Task<Event> Get(int id);
        public Task Delete(Event ev);
        public Task Update(Event ev);
        public Task<bool> CheckNameExists(string name);
    }
}
