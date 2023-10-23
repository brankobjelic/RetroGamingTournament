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
        public char GameType { get; set; }
        public ICollection<Tournament> Tournaments { get; set; }
    }
}
