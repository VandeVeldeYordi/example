using System.Collections.Generic;

namespace Pri.WebApi.Festival.Api.DTOs.Artists
{
    public class ArtistResponseDto : BaseResponseDto
    {
        public string Image { get; set; }
        public string genre{ get; set; }
        public IEnumerable<string> Festivals { get; set; }
    }
}
