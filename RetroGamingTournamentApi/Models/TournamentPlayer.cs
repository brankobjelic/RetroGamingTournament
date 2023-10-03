namespace RetroGamingTournament.Models
{
    public class TournamentPlayer
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public  Tournament Tournament { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
