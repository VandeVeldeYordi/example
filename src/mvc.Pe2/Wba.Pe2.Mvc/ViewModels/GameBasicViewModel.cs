using System.Collections;
using System.Collections.Generic;

namespace Wba.Pe2.Mvc.ViewModels
{
    public class GameBasicViewModel
    {
       
        public int Id { get; set; }
    
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }

        public ICollection<PlatformDetailsViewModel> Platforms { get; set; }

        public int MyProperty { get; set; }
    }
}
