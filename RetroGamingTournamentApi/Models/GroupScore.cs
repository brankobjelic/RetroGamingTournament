namespace RetroGamingTournament.Models
{
    public class GroupScore
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int ScoreWin { get; set; }
        public int ScoreLose { get; set; }
    }
}
