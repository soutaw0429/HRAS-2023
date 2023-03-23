using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HRAS.Models;

namespace HRAS.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<AuthController> _logger;

    public LoginController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    public IActionResult WarningPage()
    {
        return View();
    }

    public IActionResult Login(int? id)
    {

        //if (id == null)
        //{
        //    return NotFound();
        //}
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
