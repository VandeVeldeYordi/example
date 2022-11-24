using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pin.Spoticlone.Core.Dtos;
using Pin.Spoticlone.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly ITrackService _trackService;

        public AlbumsController(IAlbumService albumService, ITrackService trackService)
        {
            _albumService = albumService;
            _trackService = trackService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var albums = await _albumService.ListAllAsync();

            return Ok(albums);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var album = await _albumService.GetByIdAsync(id);
            if (album == null)
            {
                return NotFound($"Album with ID {id} does not exist");
            }

            return Ok(album);
        }

        [HttpGet("{id}/tracks")]
        public async Task<IActionResult> GetTracksByAlbum(Guid id)
        {
            var album = await _albumService.GetByIdAsync(id);
            if (album == null)
            {
                return NotFound($"Album with ID {id} does not exist");
            }

            var tracks = await _trackService.GetTracksByAlbumIdAsync(id);

            return Ok(new AlbumWithTracksResponseDto
            {
                Album = album,
                Tracks = tracks
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(AlbumRequestDto albumRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var albumResponseDto = await _albumService.AddAsync(albumRequestDto);
            return CreatedAtAction(nameof(Get), new { id = albumResponseDto.Id }, albumResponseDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlbumRequestDto albumRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var albumResponseDto = await _albumService.UpdateAsync(albumRequestDto);
            return Ok(albumResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var album = await _albumService.GetByIdAsync(id);
            if (album == null)
            {
                return NotFound($"Album with ID {id} does not exist");
            }

            await _albumService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("{id}/image"), HttpPut("{id}/image")]
        public async Task<IActionResult> Image([FromRoute] Guid id, IFormFile image)
        {
            var album = await _albumService.AddOrUpdateImageAsync(id, image);
            if (album == null)
            {
                return NotFound($"Album with ID {id} does not exist");
            }

            return Ok(album);
        }

        [HttpGet("latest")]
        public async Task<IActionResult> Latest()
        {
            var album = await _albumService.GetLatestAlbum();
            return Ok(album);
        }
    }
}
