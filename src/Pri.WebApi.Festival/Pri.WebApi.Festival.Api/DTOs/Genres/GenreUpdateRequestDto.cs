using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Festival.Api.DTOs.Genres
{
    public class GenreUpdateRequestDto
    {
        [Required(ErrorMessage = "Please provide a {0}")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string Description { get; set; }
    }
}
