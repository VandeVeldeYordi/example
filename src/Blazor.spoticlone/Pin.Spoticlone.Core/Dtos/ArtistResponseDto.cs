using Pin.Spoticlone.Core.Dtos.Base;
using System;
using System.Collections.Generic;

namespace Pin.Spoticlone.Core.Dtos
{
    public class ArtistResponseDto : DtoBase
    {
        public string Name { get; set; }
        public int Followers { get; set; }
        public int Popularity { get; set; }
        public string SpotifyId { get; set; }
        public Uri Image { get; set; }
        public ICollection<GenreResponseDto> Genres { get; set; }
        public int AlbumsCount { get; set; }
    }
}
