using Microsoft.AspNetCore.Mvc;

namespace Pri.Vue.Festivals.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}
