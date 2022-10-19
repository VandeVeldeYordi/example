using System.Collections.Generic;
using Wba.Pe2.Mvc.ViewModels.GameUpdateVms;

namespace Wba.Pe2.Mvc.ViewModels
{
    public class DevelopersInfoViewModel
    {
        public int Id { get; set; }
     
        public string Name { get; set; }

        public IEnumerable<string> Games{ get; set; }

        public IEnumerable<int> GameIds { get; set; }
    }
}
