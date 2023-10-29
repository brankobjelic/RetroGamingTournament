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
        public async Task<ActionResult> Draw(DrawRequestDTO drawRequestDTO)
        {
            if (drawRequestDTO == null)
            {
                return BadRequest();
            }

            var groups = await _service.GroupsGetDetails(drawRequestDTO);
            return Ok(groups);
        }

        [HttpPost]
        public async Task<ActionResult> Post(TournamentCreateRequestDTO tournamentDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var tournamentDetailsDTO = await _service.CreateAsync(tournamentDTO);
            return Ok(tournamentDTO);
        }

        [HttpGet]
        public IActionResult GetRoundRobin(int numberOfPlayers) 
        {
            var matches = _service.GetRoundRobin(numberOfPlayers);
            return Ok(matches);
        }
    }
}
