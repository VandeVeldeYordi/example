using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wba.Pe2.Mvc.ViewModels.DevVms
{
    public class DevelopersDetailsViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Developer")]
        public string Name { get; set; }
      
    }
}
