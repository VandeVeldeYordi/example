using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Festival.Api.DTOs.Organizers
{
    public class OrganizerUpdateRequestDto
    {
        [Required(ErrorMessage = "Please provide a {0}")]
        public int Id { get; set; }
        public OrganizerAddRequestDto Organizer{ get; set; }
    }
}
