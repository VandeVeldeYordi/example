using Pin.Spoticlone.Blazor.DTOs;

namespace Pin.Spoticlone.Blazor.Models
{
    public class Stats
    {
        public IEnumerable<Artist> TopFollowers { get; set; }
        public IEnumerable<Artist> TopPopularities { get; set; }
        public IEnumerable<Album> TopAlbumDurations { get; set; }
        public IEnumerable<Artist> TopArtistWithMostAlbums { get; set; }
        public IEnumerable<Track> TopTrackDurations { get; set; }
        public string TotalListeningTime { get; set; }
    }
}
