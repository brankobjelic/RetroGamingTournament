using System.ComponentModel.DataAnnotations;

namespace RetroGamingTournament.Models
{
    public class Player
    {
        public int Id { get; set; }
        [StringLength(5, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        [StringLength(200)]
        public string? NameAudioUrl { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public ICollection<Tournament> Tournaments { get; set; }
    }
}
