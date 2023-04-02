using Microsoft.AspNetCore.Mvc;

namespace HRAS_2023.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
