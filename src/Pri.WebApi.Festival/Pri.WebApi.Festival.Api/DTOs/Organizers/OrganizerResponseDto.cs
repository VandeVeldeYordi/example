using System.Collections.Generic;

namespace Pri.WebApi.Festival.Api.DTOs.Organizers
{
    public class OrganizerResponseDto : BaseResponseDto
    {
        public IEnumerable<string> Festivals{ get; set; }
    }
}
