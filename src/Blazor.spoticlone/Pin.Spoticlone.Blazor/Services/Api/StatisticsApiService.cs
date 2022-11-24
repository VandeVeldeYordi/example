using Pin.Spoticlone.Blazor.DTOs;
using Pin.Spoticlone.Blazor.Models;
using Pin.Spoticlone.Blazor.Services.Interfaces;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;

namespace Pin.Spoticlone.Blazor.Services.Api
{
    public class StatisticsApiService : IStatisticsApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _apiHttpClient;
       

        public StatisticsApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _apiHttpClient = _httpClientFactory.CreateClient();
            _apiHttpClient.BaseAddress = new Uri("https://localhost:5001/api/Statistics");

        }


        public async Task<IEnumerable<Artist>> GetTopFollowers(int total = 3)
        {
            var response = await _apiHttpClient.GetFromJsonAsync<StatDto>($"?totalItems={total}");


            var res = response.TopFollowers.Select(x => new Artist
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Followers = x.Followers,
                Popularity = x.Popularity,
            });                           
            return res;
        }
        public async Task<IEnumerable<Artist>> GetTopPopularity(int total = 3)
        {
            var response = await _apiHttpClient.GetFromJsonAsync<StatDto>($"?totalItems={total}");

            var res = response.TopPopularities.Select(x => new Artist
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Followers = x.Followers,
                Popularity = x.Popularity,
            });
            return res;
        }
        public async Task<IEnumerable<Album>> GetTopAlbumDurations(int total = 3)
        {
            
                var response = await _apiHttpClient.GetFromJsonAsync<StatDto>($"?totalItems={total}");

                var res = response.TopAlbumDurations.Select(x => new Album
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    Duration = x.Duration,
                    NumberOfTracks = x.NumberOfTracks,
                });
                return res;
          }

        public async Task<IEnumerable<Artist>> GetArtistWithMostAlbums(int total = 3)
        {        
                var response = await _apiHttpClient.GetFromJsonAsync<StatDto>($"?totalItems={total}");

                var res = response.TopArtistWithMostAlbums.Select(x => new Artist
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    Followers = x.Followers,
                    Popularity = x.Popularity,
                    AlbumCount = x.AlbumsCount
                });        
                return res;         
        }
        public async Task<IEnumerable<Track>> GetTopTrackDurations(int total = 3)
        {
            var response = await _apiHttpClient.GetFromJsonAsync<StatDto>($"?totalItems={total}");

            var res = response.TopTrackDurations.Select(x => new Track
            {
                Id = x.Id,
                Title = x.Title,
                DurationMs = x.Duration,
                TrackNumber = x.TrackNumber,
            });
            return res;
        }


        }
             
  
}






