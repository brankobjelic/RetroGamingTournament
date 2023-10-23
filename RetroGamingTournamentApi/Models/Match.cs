

namespace RetroGamingTournament.Models
{
    public class Match
    {
        public int Id { get; set; }
        ICollection<Player> Players { get; set; }
        ICollection<int> Scores { get; set; }
        ICollection<int>? Points { get; set; }
    }
}
