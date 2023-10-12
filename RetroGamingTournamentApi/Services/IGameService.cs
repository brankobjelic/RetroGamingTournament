using RetroGamingTournament.Models;

namespace RetroGamingTournament.Services
{
    public interface IGameService
    {
        public Task<IEnumerable<Game>> GetAsync();
    }
}
