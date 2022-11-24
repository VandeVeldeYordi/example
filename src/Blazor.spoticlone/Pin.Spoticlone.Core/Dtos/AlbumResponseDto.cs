using Pin.Spoticlone.Core.Dtos.Base;
using System;

namespace Pin.Spoticlone.Core.Dtos
{
    public class AlbumResponseDto : DtoBase
    {
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public Guid ArtistId { get; set; }
        public Uri Image { get; set; }
        public int NumberOfTracks { get; set; }
        public int NumberOfDiscs { get; set; }
        public string Duration { get; set; }
    }
}
