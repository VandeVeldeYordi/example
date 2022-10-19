using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Festival.Api.DTOs.Locations
{
    public class LocationUpdateRequestDto
    {
        [Required(ErrorMessage = "Please provide a {0}")]
        public int Id { get; set; }
        public LocationAddRequestDto Location{ get; set; }
    }
}
