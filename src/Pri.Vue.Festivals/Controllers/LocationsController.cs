using Microsoft.AspNetCore.Mvc;

namespace Pri.Vue.Festivals.Controllers
{
    public class LocationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
