

namespace RetroGamingTournament.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int NumberOfPlayers { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public GroupScore[]? Scores { get; set; }
    }
}
