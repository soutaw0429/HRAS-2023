namespace HRAS_2023.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

//[Authorize(Policy = "Admin,Junior,Senior")]
//[Authorize(Policy = "Admin")]
public class DiagnosisWizardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
