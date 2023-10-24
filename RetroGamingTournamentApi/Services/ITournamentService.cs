using RetroGamingTournament.DTO;

namespace RetroGamingTournament.Services
{
    public interface ITournamentService
    {
        public Task<IEnumerable<GroupGetDetailsResponseDTO>> GroupsGetDetails(IEnumerable<PlayerDTO> players);
        public int[][][] GetRoundRobin(int numberOfPlayers);
    }
}
