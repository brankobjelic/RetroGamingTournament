using RetroGamingTournament.DTO;
using RetroGamingTournament.Models;

namespace RetroGamingTournament.Services
{
    public interface ITournamentService
    {
        public Task<TournamentGetDetailsResponseDTO> Create(TournamentCreateRequestDTO tournamentDTO);
        public Task<IEnumerable<TournamentGetDetailsResponseDTO>> GetAsync();
        public Task<TournamentGetDetailsResponseDTO> GetDetailsAsync(int id);
        public Task<bool> DeleteAsync(int id);

        public Task<IEnumerable<Group>> CreateTournamentGroups(ICollection<int> tournamentPlayersIds);
        public int[][][] GetRoundRobin(int numberOfPlayers);
        public Task<IEnumerable<TournamentGetDetailsResponseDTO>> GetByEventIdAsync(int id);

    }
}
