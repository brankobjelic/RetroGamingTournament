
namespace RetroGamingTournament.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public ICollection<Stage> Stages { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
