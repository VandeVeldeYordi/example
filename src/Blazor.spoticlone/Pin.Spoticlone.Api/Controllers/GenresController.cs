using Microsoft.AspNetCore.Mvc;
using Pin.Spoticlone.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;
using Pin.Spoticlone.Core.Dtos;

namespace Pin.Spoticlone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IArtistService _artistService;

        public GenresController(IGenreService genreService,
            IArtistService artistService)
        {
            _genreService = genreService;
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var genres = await _genreService.ListAllAsync();

            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var genre = await _genreService.GetByIdAsync(id);
            if (genre == null)
            {
                return NotFound($"Genre with ID {id} does not exist");
            }

            return Ok(genre);
        }

        [HttpGet("{id}/artists")]
        public async Task<IActionResult> GetByGenreId(Guid id)
        {
            var artists = await _artistService.GetByGenreIdAsync(id);
            if (artists == null)
            {
                return NotFound($"Genre with ID {id} does not exist");
            }

            return Ok(artists);
        }

        [HttpPost]
        public async Task<IActionResult> Post(GenreRequestDto genreRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genreResponseDto = await _genreService.AddAsync(genreRequestDto);
            return CreatedAtAction(nameof(Get), new { id = genreResponseDto.Id }, genreResponseDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(GenreRequestDto genreRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genreResponseDto = await _genreService.UpdateAsync(genreRequestDto);
            return Ok(genreResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var genre = await _genreService.GetByIdAsync(id);
            if (genre == null)
            {
                return NotFound($"Genre with ID {id} does not exist");
            }

            await _genreService.DeleteAsync(id);
            return Ok();
        }
    }
}
