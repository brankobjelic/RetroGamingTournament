using System.ComponentModel.DataAnnotations;

namespace RetroGamingTournament.DTO
{
    public class EventCreateRequestDTO
    {
        [Required(ErrorMessage = "Event Name is required")]
        [StringLength(200)]
        public string Name { get; set; }
    }
}
