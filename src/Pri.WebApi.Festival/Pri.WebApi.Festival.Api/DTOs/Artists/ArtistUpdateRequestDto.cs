using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Festival.Api.DTOs.Artists
{
    public class ArtistUpdateRequestDto
    {

        [Required(ErrorMessage = "Please provide a {0}")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public int GenreId { get; set; }
        public IEnumerable<int> Festivals { get; set; }
    }
}
