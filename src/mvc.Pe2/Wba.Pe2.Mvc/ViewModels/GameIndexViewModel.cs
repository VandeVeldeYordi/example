using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wba.Pe2.Mvc.ViewModels
{
    public class GameIndexViewModel
    {
        public List<GameBasicViewModel> Games { get; set; }

        [Display(Name = "Number of Games")]
        public int GamesCount {  get; set; }
    }
}
