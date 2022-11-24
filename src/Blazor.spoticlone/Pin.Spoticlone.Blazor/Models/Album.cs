using Pin.Spoticlone.Blazor.DTOs;
using System.Collections.Generic;

namespace Pin.Spoticlone.Blazor.Models
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public int NumberOfTracks { get; set; }
        public Uri Image { get; set; }
        public Guid ArtistId { get; set; }
        public int NumberOfDiscs { get; set; }

        public IEnumerable<Track> Tracks { get; set; }
    }
}
