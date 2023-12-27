using RetroGamingTournament.Models;

namespace RetroGamingTournament.DTO
{
    public class TournamentGetDetailsResponseDTO
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int GameId { get; set; }
        public string GameName { get; set; }
        public bool IsActive { get; set; }
        public ICollection<StageDTO> Stages { get; set; }
        public ICollection<PlayerDTO> Players { get; set; }
        public ICollection<GroupGetDetailsResponseDTO> Groups { get; set; }
    }
}
