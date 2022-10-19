using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Festival.Api.DTOs.Festivals
{
    public class FestivalUpdateRequestDto
    {
        [Required(ErrorMessage = "Please provide a {0}")]
        public int Id { get; set; }
        //public FestivalAddRequestDto Festival { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public int LocationId { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public int OrganizerId { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please provide a value for {0}")]
        public DateTime EndDate { get; set; }
        public IEnumerable<int> Tickets { get; set; }
        public IEnumerable<int> Artists { get; set; }
    }
}
