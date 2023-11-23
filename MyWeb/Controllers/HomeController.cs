using Microsoft.AspNetCore.Mvc;

namespace MyWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
