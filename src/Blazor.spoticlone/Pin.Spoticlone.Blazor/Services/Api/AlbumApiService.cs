using Pin.Spoticlone.Blazor.DTOs;
using Pin.Spoticlone.Blazor.Models;
using Pin.Spoticlone.Blazor.Services.Interfaces;

namespace Pin.Spoticlone.Blazor.Services.Api
{
    public class AlbumApiService : IAlbumsApiService
    {     
        private string albumUrl = "https://localhost:5001/api/Albums";
        private readonly HttpClient _httpClient = null;

        public AlbumApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Album> Get(Guid id)
        {       
            var dto = await _httpClient.GetFromJsonAsync<AlbumsDto>($"{albumUrl}/{id}/tracks");
            return new Album
            {
                Id = dto.Id,
                Name = dto.Name,
                Image = dto.Image,
                Duration = dto.Duration,
                NumberOfTracks = dto.NumberOfTracks,
                Tracks = dto.Tracks.Select
                (x => new Track
                {
                    Id = x.Id,
                    Title = x.Title,
                    DurationMs = x.Duration,
                    TrackNumber = x.TrackNumber,          
                }).ToList()

            };
        }

        
        public async Task<IQueryable<Album>> GetAll()
        {
            var dtos = await _httpClient.GetFromJsonAsync<AlbumsDto[]>($"{albumUrl}");
            return dtos.Select(m => new Album
            {
                Id = m.Id,
                ArtistId = m.ArtistId,
                Name = m.Name,
                Image = m.Image,
                Duration = m.Duration,
                NumberOfTracks = m.NumberOfTracks,                         
            }).AsQueryable();
        }

    }
}
