using System.Collections.Generic;

namespace Pri.WebApi.Festival.Api.DTOs.Locations
{
    public class LocationResponseDto : BaseResponseDto
    {
        public string Postal { get; set; }
        public string City { get; set; }
        public IEnumerable<string> Festivals { get; set; }
    }
}
