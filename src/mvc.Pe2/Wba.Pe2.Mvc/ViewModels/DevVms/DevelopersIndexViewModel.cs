using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wba.Pe2.Mvc.ViewModels.DevVms;

namespace Wba.Pe2.Mvc.ViewModels
{
    public class DevelopersIndexViewModel
    {
        public List<DevelopersDetailsViewModel> Developers { get; set; } = new();
        
        [Display(Name = "Number of Developers")]
        public int DevelopersCount { get; set; }
    }
}
