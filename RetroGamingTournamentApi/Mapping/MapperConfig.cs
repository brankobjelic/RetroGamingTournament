using AutoMapper;
using RetroGamingTournament.DTO;
using RetroGamingTournament.Models;

namespace RetroGamingTournament.Mapping
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Player, PlayerCreateRequestDTO>().ReverseMap();
            CreateMap<Player, PlayerGetDetailsResponseDTO>().ReverseMap();
            CreateMap<Player, PlayerDTO>().ReverseMap();
            CreateMap<Group, GroupGetDetailsResponseDTO>().ReverseMap();
            CreateMap<Event, EventCreateRequestDTO>().ReverseMap();
            CreateMap<Event, EventGetDetailsResponseDTO>().ReverseMap();
            CreateMap<Tournament, TournamentCreateRequestDTO>().ReverseMap();
            CreateMap<Tournament, TournamentGetDetailsResponseDTO>().ReverseMap();
            CreateMap<Match, MatchDetailsResponseDTO>()
                .ForMember(dest => dest.P1Id, opt => opt.MapFrom(src => src.P1.Id))
                .ForMember(dest => dest.P2Id, opt => opt.MapFrom(src => src.P2.Id));

        }
    }
}
