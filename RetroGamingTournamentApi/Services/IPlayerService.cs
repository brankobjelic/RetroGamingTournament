using RetroGamingTournament.DTO;

namespace RetroGamingTournament.Services
{
    public interface IPlayerService
    {
        public Task<PlayerGetDetailsResponseDTO> CreateAsync(PlayerCreateRequestDTO book);
        public Task<IEnumerable<PlayerDTO>> GetAsync();
        public Task<PlayerDTO> GetDetailsAsync(int id);
        public Task<bool> DeleteAsync(int id);
    }
}
