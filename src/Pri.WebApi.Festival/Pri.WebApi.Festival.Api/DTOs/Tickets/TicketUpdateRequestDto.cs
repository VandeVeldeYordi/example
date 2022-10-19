using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Festival.Api.DTOs.Tickets
{
    public class TicketUpdateRequestDto
    {
        [Required(ErrorMessage = "Please provide a {0}")]
        public int Id { get; set; }
        public TicketAddRequestDto Ticket { get; set; }
    }
}
