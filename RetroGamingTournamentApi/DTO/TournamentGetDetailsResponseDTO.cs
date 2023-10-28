using RetroGamingTournament.Models;

namespace RetroGamingTournament.DTO
{
    public class TournamentGetDetailsResponseDTO
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public ICollection<Stage> Stages { get; set; }
    }
}
