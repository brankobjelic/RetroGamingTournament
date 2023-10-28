using RetroGamingTournament.Models;

namespace RetroGamingTournament.Repositories
{
    public interface ITournamentRepository
    {
        public Task<Tournament> Create(Tournament tournament);
        public Task<IEnumerable<Tournament>> GetAll();
        public Task<Tournament> Get(int id);
        public Task Delete(Tournament tournament);
    }
}
