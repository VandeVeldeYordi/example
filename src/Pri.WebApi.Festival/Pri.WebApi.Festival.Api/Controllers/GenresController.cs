using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pri.Festivals.Core.InterFaces.Services;
using Pri.WebApi.Festival.Api.DTOs.Genres;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.WebApi.Festival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet("{id}")]
        //[Authorize(Policy = "customer")]
        public async Task<IActionResult> GetById(int id)
        {
            //get genres
            var genre = await _genreService.GetByIdAsync(id);
            if (!genre.IsSuccess)
            {
                return BadRequest(genre.ValidationErrors);
            }
            GenreResponseDto genreResponseDto = new GenreResponseDto
            {
                Name = genre.Items.First().Name,
                Description = genre.Items.First().Description,
                Artists = genre.Items.First().Artists.Select(ge => ge.Name)
            };
            return Ok(genreResponseDto);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var genres = await _genreService.GetAllAsync();
            var genreResponseDto = genres.Items.Select(g =>
            new GenreResponseDto
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description,
                Artists = g.Artists.Select(ge => ge.Name)
            });
            return Ok(genreResponseDto);
        }
        [HttpPost]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Add(GenreAddRequestDto genreAddRequestDto)
        {
            //check for model errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            //check for database errors
            var result = await _genreService.Add(
                genreAddRequestDto.Name,
                genreAddRequestDto.Description
                //genreAddRequestDto.Artists
                );
            if (!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }
            return Ok("Genre added");
        }
        [HttpPut]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Update(GenreUpdateRequestDto genreUpdateRequestDto)
        {
            //check for validation errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            var result = await _genreService.UpdateAsync(
                genreUpdateRequestDto.Id,
                genreUpdateRequestDto.Name,
                genreUpdateRequestDto.Description
                //genreUpdateRequestDto.Genre.Artists
                );
            if (!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }
            return Ok("Genre Updated");
        }
        [HttpDelete]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var genreEnity = await _genreService.GetByIdAsync(id);
            if (genreEnity.IsSuccess == false)
            {
                return NotFound($"No genre with an id of {id}");
            }
            await _genreService.DeleteAsync(id);
            return Ok("Genre deleted");
        }
    }
}
