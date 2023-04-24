using Microsoft.AspNetCore.Mvc;

namespace HRAS_2023.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
