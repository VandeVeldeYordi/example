using Microsoft.AspNetCore.Mvc;
using Pin.Spoticlone.Core.Dtos;
using Pin.Spoticlone.Core.Interfaces.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly ITrackService _trackService;

        public TracksController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string title)
        {
            if (title != null)
            {
                var tracks = await _trackService.SearchByNameAsync(title);
                if (tracks.Any())
                {
                    return Ok(tracks);
                }
                return NotFound($"There were no tracks found that contain {title} in their title");
            }
            else
            {
                var tracks = await _trackService.ListAllAsync();
                return Ok(tracks);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var track = await _trackService.GetByIdAsync(id);
            if (track == null)
            {
                return NotFound($"Track with ID {id} does not exist");
            }

            return Ok(track);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TrackRequestDto trackRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trackResponseDto = await _trackService.AddAsync(trackRequestDto);
            return CreatedAtAction(nameof(Get), new { id = trackResponseDto.Id }, trackResponseDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(TrackRequestDto trackRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trackResponseDto = await _trackService.UpdateAsync(trackRequestDto);
            return Ok(trackResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var track = await _trackService.GetByIdAsync(id);
            if (track == null)
            {
                return NotFound($"Track with ID {id} does not exist");
            }

            await _trackService.DeleteAsync(id);
            return Ok();
        }
    }
}
