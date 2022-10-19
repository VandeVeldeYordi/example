using System.Collections.Generic;

namespace Wba.Pe2.Mvc.ViewModels
{
    public class CategoryIndexViewModel
    {
        public List<CategoryDetailsViewModel> Categories { get; set; } = new();
    }
}
