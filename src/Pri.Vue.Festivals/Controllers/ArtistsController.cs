using Microsoft.AspNetCore.Mvc;

namespace Pri.Vue.Festivals.Controllers
{
    public class ArtistsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
    }
}
