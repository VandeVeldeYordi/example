using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Spoticlone.Core.Dtos
{
    public class AlbumWithTracksResponseDto
    {
        public AlbumResponseDto Album { get; set; }
        public IEnumerable<TrackResponseDto> Tracks { get; set; }
    }
}
