using RetroGamingTournament.DTO;
using RetroGamingTournament.Models;
using RetroGamingTournament.Repositories;

namespace RetroGamingTournament.Services
{
    public class GameService : IGameService
    {
        public readonly IGameRepository _repository;
        public GameService(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Game>> GetAsync()
        {
            var games = await _repository.GetAll();
            return games;
        }
    }
}
