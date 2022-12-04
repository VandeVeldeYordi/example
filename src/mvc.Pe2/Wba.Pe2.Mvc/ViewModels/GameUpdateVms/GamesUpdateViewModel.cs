using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wba.Pe2.Mvc.Models;

namespace Wba.Pe2.Mvc.ViewModels.GameUpdateVms
{
    public class GamesUpdateViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date required!")]
        [DataType(DataType.Date)]
        [Display(Name = "Game release date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Game price")]
        public decimal Price { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        public List<CheckboxHelper> Characters { get; set; }

        public List<SelectListItem> Category { get; set; }

        public List<SelectListItem> Developers { get; set; }

        public List<CheckboxHelper> Properties { get; set; }

        public List<CheckboxHelper> Platforms { get; set; }

        [Display(Name ="Game developer")]
        public int? DeveloperId { get; set; }

        [Display(Name = "Game category")]
        public int? CategoryId { get; set; }
    }
}
