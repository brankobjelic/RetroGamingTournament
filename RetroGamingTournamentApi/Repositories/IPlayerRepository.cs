using RetroGamingTournament.Models;

namespace RetroGamingTournament.Repositories
{
    public interface IPlayerRepository
    {
        public Task<Player> Create(Player player);
        public Task<IEnumerable<Player>> GetAll();
        public Task<Player> Get(int id);
        public Task Delete(Player player);
    }
}
