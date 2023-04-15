using Microsoft.AspNetCore.Mvc;

namespace HRAS_2023.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
