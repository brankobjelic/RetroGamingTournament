using RetroGamingTournament.DTO;

namespace RetroGamingTournament.Services
{
    public interface ITournamentService
    {
        public Task<TournamentGetDetailsResponseDTO> CreateAsync(TournamentCreateRequestDTO tournamentDTO);
        public Task<IEnumerable<TournamentGetDetailsResponseDTO>> GetAsync();
        public Task<TournamentGetDetailsResponseDTO> GetDetailsAsync(int id);
        public Task<bool> DeleteAsync(int id);

        public Task<IEnumerable<GroupGetDetailsResponseDTO>> GroupsGetDetails(DrawRequestDTO drawRequestDTO);
        public int[][][] GetRoundRobin(int numberOfPlayers);
    }
}
