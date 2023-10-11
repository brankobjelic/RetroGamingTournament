using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetroGamingTournament.DTO;
using RetroGamingTournament.Services;

namespace RetroGamingTournament.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _service;
        private readonly IFileService _fileService;
        public PlayersController(IPlayerService service, IFileService fileService)
        {
            _service = service;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerGetDetailsResponseDTO>>> Get()
        {
            var result = await _service.GetAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(int id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("Audio/{filename}")]
        public IActionResult GetAudio(string filename)
        {
            var fileBytes = _fileService.GetAudioFile(filename);
            if (fileBytes == null)
            {
                return NotFound(); // Or handle the scenario when the audio file is not found
            }

            string mimeType;
            switch (Path.GetExtension(filename))
            {
                case ".mp3":
                    mimeType = "audio/mpeg";
                    break;
                case ".wav":
                    mimeType = "audio/wav";
                    break;
                case ".ogg":
                    mimeType = "audio/ogg";
                    break;
                default:
                    mimeType = "application/octet-stream"; // Fallback MIME type if extension is unknown
                    break;
            }

            return File(fileBytes, mimeType);
        }
    }
}
