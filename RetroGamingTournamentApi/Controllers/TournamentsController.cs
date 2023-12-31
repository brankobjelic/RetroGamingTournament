﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public async Task<ActionResult> Post(TournamentCreateRequestDTO tournamentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var tournamentDetailsDTO = await _service.Create(tournamentDTO);
            return CreatedAtAction("Get", new {id = tournamentDetailsDTO.Id}, tournamentDetailsDTO);
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult> GetByEventId(int eventId)
        {
            var tournaments = await _service.GetByEventIdAsync(eventId);
            return Ok(tournaments);

        }

        [HttpGet]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _service.GetDetailsAsync(id);
            return Ok(result);
        }
    }
}
