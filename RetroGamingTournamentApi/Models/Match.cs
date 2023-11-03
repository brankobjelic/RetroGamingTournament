

using System.ComponentModel.DataAnnotations.Schema;

namespace RetroGamingTournament.Models
{
    public class Match
    {
        public int Id { get; set; }
        //public int P1Id { get; set; }
        public Player P1 { get; set; }
        //public int P2Id { get; set; }
        public Player P2 { get; set; }
        public int? ScoreP1 { get; set; }
        public int? ScoreP2 { get; set; }
        public int? PointsP1 { get; set; }
        public int? PointsP2 { get; set; }
        //public ICollection<Player> Players { get; set; }
        //public ICollection<int>? Scores { get; set; }
        //public ICollection<int>? Points { get; set; }
    }
}
