using System.ComponentModel.DataAnnotations;

namespace RetroGamingTournament.Models
{
    public class Stage
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}
