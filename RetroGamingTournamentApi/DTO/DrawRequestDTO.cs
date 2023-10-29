namespace RetroGamingTournament.DTO
{
    public class DrawRequestDTO
    {
        public int TournamentId { get; set; }
        public List<int> TournamentPlayersIds { get; set; }
    }
}
