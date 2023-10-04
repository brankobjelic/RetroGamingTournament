﻿using AutoMapper;
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
        }
    }
}
