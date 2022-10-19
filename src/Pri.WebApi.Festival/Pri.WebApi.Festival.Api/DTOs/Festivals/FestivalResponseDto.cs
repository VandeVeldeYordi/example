using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Pri.WebApi.Festival.Api.DTOs.Festivals
{
    public class FestivalResponseDto: BaseResponseDto
    {
        public string Image { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int OrganizerId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public IEnumerable<string> Tickets { get; set; }
        public IEnumerable<string> Artists { get; set; }
        public string LocationName { get; set; }
        public string OrganizerName { get; set; }
    }
}
