
namespace RetroGamingTournament.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public ICollection<Stage> TournamentStages { get; set; }
        public ICollection<Player> TournamentPlayers { get; set; }
        public ICollection<Group> TournamentGroups { get; set; }
        public ICollection<Match> TournamentMatches { get; set; }
    }
}
