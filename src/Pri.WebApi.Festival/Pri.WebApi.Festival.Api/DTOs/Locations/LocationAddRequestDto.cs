using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Festival.Api.DTOs.Locations
{
    public class LocationAddRequestDto
    {

        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Please Enter a valid postal Code")]
        public string Postal { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string City { get; set; }
        //public IEnumerable<int> Festivals { get; set; }
    }
}
