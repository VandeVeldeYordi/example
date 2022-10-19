using System.Collections.Generic;

namespace Pri.WebApi.Festival.Api.DTOs.Genres
{
    public class GenreResponseDto : BaseResponseDto
    {
        public string Description { get; set; }
        public IEnumerable<string> Artists { get; set; }
    }
}
