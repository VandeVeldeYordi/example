using System.Collections.Generic;

namespace Pin.Spoticlone.Core.Dtos
{
    public class StatisticsResponseDto
    {
        public IEnumerable<ArtistResponseDto> TopFollowers { get; set; }
        public IEnumerable<ArtistResponseDto> TopPopularities { get; set; }
        public IEnumerable<AlbumResponseDto> TopAlbumDurations { get; set; }
        public IEnumerable<ArtistResponseDto> TopArtistWithMostAlbums { get; set; }
        public IEnumerable<TrackResponseDto> TopTrackDurations { get; set; }
        public string TotalListeningTime { get; set; }
    }
}
