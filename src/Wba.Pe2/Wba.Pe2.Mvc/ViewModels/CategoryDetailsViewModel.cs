using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wba.Pe2.Mvc.ViewModels
{
    public class CategoryDetailsViewModel
    {
        public  int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Category name")]
        public string Name { get; set; }
  
    }
}
