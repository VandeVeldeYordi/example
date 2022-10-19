using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Festival.Api.DTOs.Organizers
{
    public class OrganizerAddRequestDto
    {
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string Name { get; set; }
        //public IEnumerable<int> Festivals{ get; set; }
    }
}
