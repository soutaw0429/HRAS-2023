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
        return View();
    }
    public IActionResult ProcessLogin(Staff staffMember) 
    {
        if (staffMember.userName == "JohnDoe" && staffMember.password == "testLogin")
        {
            return View("LoginSuccess", staffMember);
        }
        else
        {
            return View("LoginFailure", staffMember);
        }

        // Bellow is example of what will be implemented after service is created. 
        // StaffSecurity staff = new StaffSecurity();

        // if (staff.IsValid(staffMember))
        // {
        //    return View("LoginSuccess", staffMember);
        // }
        // else
        // {
        //    return View("LoginFailure", staffMember);
        // }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
