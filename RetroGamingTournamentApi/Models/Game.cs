using System.ComponentModel.DataAnnotations;

namespace RetroGamingTournament.Models
{
    public class Game
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        public string? BannerFile { get; set; }
        public int NumberOfPlayers { get; set; }
    }
}
