using Pin.Spoticlone.Blazor.Models;

namespace Pin.Spoticlone.Blazor.Services.Interfaces
{
    public interface IStatisticsApiService
    {
        Task<IEnumerable<Artist>> GetTopFollowers(int total);
        Task<IEnumerable<Artist>> GetTopPopularity(int total);
        Task<IEnumerable<Album>> GetTopAlbumDurations(int total);
        Task<IEnumerable<Track>> GetTopTrackDurations(int total);
        Task<IEnumerable<Artist>> GetArtistWithMostAlbums(int total);

    }
}