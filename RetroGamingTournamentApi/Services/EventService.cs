using AutoMapper;
using RetroGamingTournament.DTO;
using RetroGamingTournament.Models;
using RetroGamingTournament.Repositories;

namespace RetroGamingTournament.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<EventGetDetailsResponseDTO> CreateAsync(EventCreateRequestDTO ev)
        {
            var eventEntity = _mapper.Map<Event>(ev);
            eventEntity.EventDate = DateTime.Now;
            try
            {
                var result = await _eventRepository.Create(eventEntity);
                return _mapper.Map<EventGetDetailsResponseDTO>(result);
            }
            catch
            {
                throw;
            }
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
