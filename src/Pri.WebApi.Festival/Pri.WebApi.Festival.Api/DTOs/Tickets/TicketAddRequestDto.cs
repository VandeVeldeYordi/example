using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Festival.Api.DTOs.Tickets
{
    public class TicketAddRequestDto
    {
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public decimal Price{ get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public int Available { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public int TicketsSold { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public int FestivalId { get; set; }
    }
}
