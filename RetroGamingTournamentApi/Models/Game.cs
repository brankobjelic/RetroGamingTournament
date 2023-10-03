using System.ComponentModel.DataAnnotations;

namespace RetroGamingTournament.Models
{
    public class Game
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        public string? Banner { get; set; }
    }
}
