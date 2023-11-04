using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RetroGamingTournament.DTO;
using RetroGamingTournament.Services;
using System.Net;

namespace RetroGamingTournament.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _service;
        public EventsController(IEventService eventService)
        {
            _service = eventService;
        }
        [HttpPost]
        public async Task<ActionResult> Post(EventCreateRequestDTO ev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                bool eventNameExists = await _service.NameExists(ev);
                if (eventNameExists) 
                {
                    return Conflict("The event name is already taken.");
                }
            }
            catch (SqlException ex)
            {
                // Handle database connectivity issues
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Database connection error.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred during event registration.");
            }
            try
            {
                await _service.CreateAsync(ev);
            }
            catch (SqlException ex)
            {
                // Handle database connectivity issues
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Database connection error.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred during event registration.");
            }
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventGetDetailsResponseDTO>>> Get()
        {
            var events = await _service.GetAsync();
            return Ok(events);
        }
    }
}
