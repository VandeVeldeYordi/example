using AutoMapper;
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
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IAlbumService _albumService;
        private readonly IMapper _mapper;

        public ArtistsController(IArtistService artistService, IAlbumService albumService, IMapper mapper)
        {
            _artistService = artistService;
            _albumService = albumService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var artists = await _artistService.ListAllAsync();

            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var artist = await _artistService.GetByIdAsync(id);
            if (artist == null)
            {
                return NotFound($"Artist with ID {id} does not exist");
            }

            return Ok(artist);
        }

        [HttpGet("{artistId}/albums")]
        public async Task<IActionResult> GetArtistWithAlbums(Guid artistId)
        {
            var artist = await _artistService.GetByIdAsync(artistId);
            if (artist == null)
            {
                return NotFound($"Artist with ID {artistId} does not exist");
            }

            var albums = await _albumService.GetAlbumsFromArtistAsync(artistId);

            var response = new ArtistWithAlbumsResponseDto
            {
                Artist = artist,
                Albums = albums
            };

            return Ok(response);
        }
    }
}
