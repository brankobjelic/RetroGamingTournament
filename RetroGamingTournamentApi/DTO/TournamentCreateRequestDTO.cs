using RetroGamingTournament.Models;
using System.ComponentModel.DataAnnotations;

namespace RetroGamingTournament.DTO
{
    public class TournamentCreateRequestDTO
    {
        [Required]
        public int EventId { get; set; }
        [Required]
        public int GameId { get; set; }
        public List<int> TournamentPlayersIds { get; set; }
    }
}
