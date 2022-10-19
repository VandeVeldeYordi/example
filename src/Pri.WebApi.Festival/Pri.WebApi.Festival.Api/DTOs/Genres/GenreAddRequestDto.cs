using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Festival.Api.DTOs.Genres
{
    public class GenreAddRequestDto
    {
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string Description { get; set; }
        //public IEnumerable<int> Artists { get; set; }
    }
}
