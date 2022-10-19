using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wba.Pe2.Mvc.ViewModels.Components;

namespace Wba.Pe2.Mvc.Components
{
    [ViewComponent(Name = "MainNavigation")]
    public class MainNavComponent : ViewComponent
    {
        private IEnumerable<MainNavLinkVm> NavigationLinks { get; set; }
        public MainNavComponent()
        {
            NavigationLinks = new List<MainNavLinkVm>
             {
             new MainNavLinkVm{
                 Area=null, Controller="Home", Action="Index", Text="Home"
             },
             new MainNavLinkVm{
                 Area=null, Controller="Developers", Action="Index", Text="Developers"
             },
             new MainNavLinkVm{
               Area=null, Controller="Games", Action="Index", Text="Games"
              },
              new MainNavLinkVm{
               Area=null, Controller="Categories", Action="Index", Text="Categories"
              },
                new MainNavLinkVm{
               Area=null, Controller="Platforms", Action="Index", Text="Platforms"
              }
           };
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            foreach (var lnk in NavigationLinks)
            {
                if (this.RouteData.Values["area"]?.ToString().ToLower() == lnk.Area?.ToLower() &&
                this.RouteData.Values["controller"]?.ToString().ToLower() == lnk.Controller.ToLower() &&
                this.RouteData.Values["action"]?.ToString().ToLower() == lnk.Action.ToLower())
                {
                    lnk.IsActive = true;
                }
            }
            return await Task.FromResult<IViewComponentResult>(View(NavigationLinks));
        }
    }
}
