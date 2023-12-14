using RetroGamingTournament.DTO;

namespace RetroGamingTournament.Services
{
    public interface IEventService
    {
        public Task<EventGetDetailsResponseDTO> CreateAsync(EventCreateRequestDTO ev);
        public Task<IEnumerable<EventGetDetailsResponseDTO>> GetAsync();
        public Task<EventGetDetailsResponseDTO> GetDetailsAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> NameExists(EventCreateRequestDTO ev);
        public Task<EventGetDetailsResponseDTO> GetActiveAsync();

    }
}
