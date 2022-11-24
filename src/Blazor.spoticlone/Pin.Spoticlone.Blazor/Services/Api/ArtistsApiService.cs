using Pin.Spoticlone.Blazor.DTOs;
using Pin.Spoticlone.Blazor.Models;
using Pin.Spoticlone.Blazor.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Pin.Spoticlone.Blazor.Services.Api
{
    public class ArtistsApiService : IArtistsApiService
    {
        private string baseUrl = "https://localhost:5001/api/Artists";
        private string albumUrl = "https://localhost:5001/api/Albums";
        private readonly HttpClient _httpClient = null;

        public ArtistsApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<Artist> Get(Guid id)
        {
          
            var dto = await _httpClient.GetFromJsonAsync<ArtistDto>($"{baseUrl}/{id}");
            var dtos = await _httpClient.GetFromJsonAsync<AlbumsDto[]>($"{albumUrl}");
            var artists = await _httpClient.GetFromJsonAsync<ArtistDto[]>($"{baseUrl}");
            return new Artist
            {
                Id = dto.Id,
                Name = dto.Name,
                Image = dto.Image,
                Followers = dto.Followers,
                Popularity = dto.Popularity,
                SpotifyId = dto.SpotifyId,
                GenresName = dto.Genres.Select(x => x.Name).ToList(),
                AlbumCount = dto.AlbumsCount,
                Albums = dtos.Select(x => new Album
                {
                    Id = x.Id,
                    ArtistId = x.ArtistId,
                    Name = x.Name,
                    Image = x.Image,
                    Duration = x.Duration,
                    NumberOfTracks = x.NumberOfTracks,
                    NumberOfDiscs = x.NumberOfDiscs,
                    
                }).Where(x => x.ArtistId == dto.Id).ToList(),
                ArtistsWithSameGenre = artists.Select(x => new Artist
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    GenresName = x.Genres.Select(x => x.Name).ToList(),
                }).Where(y => y.GenresName.Where(dto.Genres.Select(x => x.Name).ToList().Contains).Any()).ToList()
            };
        }
        public async Task<IQueryable<Artist>> GetAll()
        {
            var dtos = await _httpClient.GetFromJsonAsync<ArtistDto[]>($"{baseUrl}");
            return dtos.Select(m => new Artist
            {
                Id = m.Id,
                Name = m.Name,
                Image = m.Image,
                Followers = m.Followers,
                Popularity = m.Popularity,
                SpotifyId = m.SpotifyId,
                GenresName = m.Genres.Select(x => x.Name).ToList()
            }).AsQueryable();
        }

    }
}
