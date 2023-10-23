using System.ComponentModel.DataAnnotations;

namespace RetroGamingTournament.Models
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public ICollection<Player> Players { get; set; }

    }
}
