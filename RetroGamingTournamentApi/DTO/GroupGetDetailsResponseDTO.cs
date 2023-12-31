﻿using RetroGamingTournament.Models;

namespace RetroGamingTournament.DTO
{
    public class GroupGetDetailsResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfGroupContestants { get; set; }
        public ICollection<PlayerDTO> Players { get; set; }
        public ICollection<MatchDetailsResponseDTO> Matches { get; set; }

    }
}
