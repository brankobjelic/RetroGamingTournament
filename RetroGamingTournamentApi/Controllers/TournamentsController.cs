using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetroGamingTournament.DTO;
using RetroGamingTournament.Services;

namespace RetroGamingTournament.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly ITournamentService _service;
        public TournamentsController(ITournamentService tournamentService)
        {
            _service = tournamentService;
        }
        [HttpPost]
        [Route("Draw")]
        public async Task<ActionResult> Draw(IEnumerable<PlayerDTO> players)
        {
            if (players == null)
            {
                return BadRequest();
            }

            var groups = await _service.GroupsGetDetails(players);
            return Ok(groups);
        }
    }
}
