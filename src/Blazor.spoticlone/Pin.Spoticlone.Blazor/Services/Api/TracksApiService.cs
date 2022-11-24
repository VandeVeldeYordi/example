using Pin.Spoticlone.Blazor.DTOs;
using Pin.Spoticlone.Blazor.Models;

namespace Pin.Spoticlone.Blazor.Services.Api
{
    public class TracksApiService : ICRUDService<Track>
    {
        private string TrackUrl = "https://localhost:5001/api/Tracks";
        private readonly HttpClient _httpClient = null;

        public TracksApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //get tracks by album Id
        public async Task<IQueryable<Track>> Get(Guid id)
        {
            var dtos = await _httpClient.GetFromJsonAsync<TracksDto[]>($"{TrackUrl}");
            return dtos.Select(dto => new Track
            {
                Id = dto.Id,
                Title = dto.Title,
                DurationMs = dto.Duration,
                DiscNumber = dto.DiscNumber,
                TrackNumber = dto.TrackNumber,
                AlbumId = dto.AlbumId,
                AlbumName = dto.AlbumName,
                Explicit = dto.Explicit,

            }).Where(x => x.AlbumId == id).AsQueryable();
         
        }
        public async Task<Track> GetTrackById(Guid id)
        {
            var dto = await _httpClient.GetFromJsonAsync<TracksDto>($"{TrackUrl}/{id}");
            return new Track
            {
                Id = dto.Id,
                Title = dto.Title,
                DurationMs = dto.Duration,
                DiscNumber = dto.DiscNumber,
                TrackNumber = dto.TrackNumber,
                AlbumId = dto.AlbumId,
                AlbumName = dto.AlbumName,
                Explicit = dto.Explicit,
            };
        }
        public async Task<IQueryable<Track>> GetAll()
        {
            var dtos = await _httpClient.GetFromJsonAsync<TracksDto[]>($"{TrackUrl}");
            return dtos.Select(dto => new Track
            {
                Id = dto.Id,
                Title = dto.Title,
                DurationMs = dto.Duration,
                Explicit = dto.Explicit,
                DiscNumber = dto.DiscNumber,
                TrackNumber = dto.TrackNumber,
                AlbumId = dto.AlbumId,
            }).AsQueryable();
        }
        public Task Create(Track item)
        {
            var dto = new TracksUpdateDto
            {          
                Name = item.Title,
                Duration = item.DurationMs,
                Explicit = item.Explicit,
                DiscNumber = item.DiscNumber,
                TrackNumber = item.TrackNumber,
                AlbumId = item.AlbumId,
            };
            return _httpClient.PostAsJsonAsync($"{TrackUrl}", dto);
        }

        public Task Delete(Guid id)
        {
            return _httpClient.DeleteAsync($"{TrackUrl}/{id}");
        }
        public Task Update(Track item)
        {
            var dto = new TracksUpdateDto
            {
                Id = item.Id,
                Name = item.Title,
                Duration = item.DurationMs,
                Explicit = item.Explicit,
                DiscNumber = item.DiscNumber,
                TrackNumber = item.TrackNumber,
                AlbumId = item.AlbumId,
            };
            return _httpClient.PutAsJsonAsync($"{TrackUrl}", dto);
        }
    }
}
