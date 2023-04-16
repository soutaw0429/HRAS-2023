using Microsoft.AspNetCore.Mvc;

namespace HRAS_2023.Controllers
{
    public class DiagnosisWizardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
