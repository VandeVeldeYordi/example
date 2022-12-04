using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wba.Pe2.Mvc.ViewModels
{
    public class PlatformDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Platform")]
        public string Name { get; set; }


    }
}
