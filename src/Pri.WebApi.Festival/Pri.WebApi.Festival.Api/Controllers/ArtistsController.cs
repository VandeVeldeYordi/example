using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pri.Festivals.Core.InterFaces.Services;
using Pri.WebApi.Festival.Api.DTOs.Artists;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.WebApi.Festival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ArtistsController(IArtistService artistService , IHttpContextAccessor httpContextAccessor)
        {
            _artistService = artistService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("{id}")]
        //[Authorize(Policy = "customer")]
        public async Task<IActionResult> GetById(int id)
        {
            //get artist
            var artist= await _artistService.GetByIdAsync(id);
            if (!artist.IsSuccess)
            {
                return BadRequest(artist.ValidationErrors);
            }
            ArtistResponseDto artistResponseDto = new ArtistResponseDto
            {
                Name = artist.Items.First().Name,
                genre = artist.Items.First().Name,
                Image = artist.Items.First().Image,         
                Festivals = artist.Items.First().Festivals.Select(fe => fe.Name)
            };
            return Ok(artistResponseDto);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var artist = await _artistService.GetAllAsync();
            var artistResponseDto = artist.Items.Select(l =>
            new ArtistResponseDto
            {
                Id = l.Id,
                Name = l.Name,
                genre = l.Genre.Name,
                Image = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/images/Artist/{l.Image}",
                Festivals = l.Festivals.Select(lo => lo.Name)
            });
            return Ok(artistResponseDto);
        }
        [HttpPost]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Add([FromForm] ArtistAddRequestDto artistAddRequestDto)
        {
            //check for model errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            if (await _artistService.Add(artistAddRequestDto.Name,
                artistAddRequestDto.GenreId,
              artistAddRequestDto.Image,
                artistAddRequestDto.Festivals))
            {
                return Ok("Artist added");
            }
            return BadRequest("Artist not added! Try again!");

        }
        [HttpPut]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Update([FromForm] ArtistUpdateRequestDto artistUpdateRequestDto)
        {
            //check for validation errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            if (await _artistService.UpdateAsync(artistUpdateRequestDto.Id ,artistUpdateRequestDto.Name,
                artistUpdateRequestDto.GenreId,
              artistUpdateRequestDto.Image,
                artistUpdateRequestDto.Festivals))
            {
                return Ok("artist updated");
            }
            return BadRequest("something went wrong");
          
        }
        [HttpDelete]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var artistEnity = await _artistService.GetByIdAsync(id);
            if (artistEnity.IsSuccess == false)
            {
                return NotFound($"No artist with an id of {id}");
            }
            await _artistService.DeleteAsync(id);
            return Ok("Artist deleted");
        }
        [HttpGet("genre/{id}")]
        //[Authorize(Policy = "customer")]
        public async Task<IActionResult> GetByGenreId(int id)
        {
            var artists = await _artistService.GetByGenreyIdAsync(id);
            if (!artists.IsSuccess)
            {
                return BadRequest(artists.ValidationErrors);
            }
            var artistResponseDto = artists.Items.Select(
                a => 
                new ArtistResponseDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    genre = a.Genre.Name,
                    Image = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/images/Artist/{a.Image}",
                    Festivals = a.Festivals.Select(lo => lo.Name)
                }
                );
            return Ok(artistResponseDto);
        }
    }
}
