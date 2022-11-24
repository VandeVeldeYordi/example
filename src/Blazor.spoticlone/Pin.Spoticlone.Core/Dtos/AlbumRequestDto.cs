using Pin.Spoticlone.Core.Dtos.Base;
using System;

namespace Pin.Spoticlone.Core.Dtos
{
    public class AlbumRequestDto : DtoBase
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Uri Image { get; set; }
        public Guid ArtistId { get; set; }
    }
}
