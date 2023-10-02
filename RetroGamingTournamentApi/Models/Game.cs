using System.ComponentModel.DataAnnotations;

namespace RetroGamingTournament.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Banner { get; set; }
    }
}
