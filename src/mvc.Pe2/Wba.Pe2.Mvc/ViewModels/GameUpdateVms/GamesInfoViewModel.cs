using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wba.Pe2.Mvc.ViewModels.GameUpdateVms
{
    public class GamesInfoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Game title")]
        public string Title { get; set; }

        [Display(Name = "Game release date")]     
        public DateTime? ReleaseDate { get; set; }
  
        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        public IEnumerable<BaseViewModel> Characters { get; set; }

        public  BaseViewModel Category { get; set; }

        public BaseViewModel Developers { get; set; }
     
        public IEnumerable<BaseViewModel> Properties { get; set; }

        public IEnumerable<BaseViewModel> Platforms { get; set; }

    }
}
