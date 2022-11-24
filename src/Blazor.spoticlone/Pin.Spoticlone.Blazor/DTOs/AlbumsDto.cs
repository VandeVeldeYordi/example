using Pin.Spoticlone.Blazor.Models;

namespace Pin.Spoticlone.Blazor.DTOs
{
    public class AlbumsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public int NumberOfTracks { get; set; }
        public Uri Image { get; set; }
        public Guid ArtistId { get; set; }
        public int NumberOfDiscs { get; set; }
        public IEnumerable<TracksDto> Tracks { get; set; }
    }
}
