using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pin.Spoticlone.Core.Dtos.Base;

namespace Pin.Spoticlone.Core.Dtos
{
    public class TrackResponseDto : DtoBase
    {
        public string Title { get; set; }
        public string Duration { get; set; }
        public bool Explicit { get; set; }
        public int TrackNumber { get; set; }
        public int DiscNumber { get; set; }
        public string AlbumName { get; set; }
        public Guid AlbumId { get; set; }
    }
}
