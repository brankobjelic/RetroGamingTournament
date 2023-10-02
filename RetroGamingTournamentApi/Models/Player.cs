using System.ComponentModel.DataAnnotations;

namespace RetroGamingTournament.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 2)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
