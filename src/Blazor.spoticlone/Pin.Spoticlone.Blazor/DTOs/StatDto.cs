using System.Text.Json.Serialization;

namespace Pin.Spoticlone.Blazor.DTOs
{
    public class StatDto
    {
        [JsonPropertyName("topFollowers")]
        public IEnumerable<ArtistDto> TopFollowers { get; set; }
        [JsonPropertyName("topPopularities")]
        public IEnumerable<ArtistDto> TopPopularities { get; set; }
        [JsonPropertyName("topAlbumDurations")]
        public IEnumerable<AlbumsDto> TopAlbumDurations { get; set; }
        [JsonPropertyName("topArtistWithMostAlbums")]
        public IEnumerable<ArtistDto> TopArtistWithMostAlbums { get; set; }
        [JsonPropertyName("topTrackDurations")]
        public IEnumerable<TracksDto> TopTrackDurations { get; set; }
        public string TotalListeningTime { get; set; }
    }
}
