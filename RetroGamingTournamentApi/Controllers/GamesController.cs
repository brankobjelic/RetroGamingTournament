using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetroGamingTournament.DTO;
using RetroGamingTournament.Services;

namespace RetroGamingTournament.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _service;
        public GamesController(IGameService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDTO>>> Get()
        {
            var result = await _service.GetAsync();
            return Ok(result);
        }
    }
}
