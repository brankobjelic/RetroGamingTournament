using System.ComponentModel.DataAnnotations;

namespace RetroGamingTournament.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public bool IsActive { get; set; }
        ICollection<Tournament> Tournaments { get; set; }
    }
}
