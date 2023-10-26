using RetroGamingTournament.DTO;
using RetroGamingTournament.Repositories;

namespace RetroGamingTournament.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public Task<EventGetDetailsResponseDTO> CreateAsync(EventCreateRequestDTO ev)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventGetDetailsResponseDTO>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EventGetDetailsResponseDTO> GetDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> NameExists(EventCreateRequestDTO ev)
        {
            return _eventRepository.CheckNameExists(ev.Name);
        }
    }
}
