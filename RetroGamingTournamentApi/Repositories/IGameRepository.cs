using RetroGamingTournament.Models;

namespace RetroGamingTournament.Repositories
{
    public interface IGameRepository
    {
        public Task<Game> Create(Game game);
        public Task<IEnumerable<Game>> GetAll();
        public Task<Game> Get(int id);
        public Task Delete(Game game);
    }
}
