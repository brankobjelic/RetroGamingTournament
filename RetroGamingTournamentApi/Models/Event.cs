namespace RetroGamingTournament.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        ICollection<Tournament> Tournaments { get; set; }
    }
}
