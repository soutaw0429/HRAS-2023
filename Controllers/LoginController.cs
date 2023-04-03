using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using HRAS.Interfaces;
using HRAS.Models;

namespace HRAS.Controllers;

public class LoginController : Controller
{
    private readonly ISecurityService _security;
    private readonly ILogger<AuthController> _logger;

    public LoginController(ISecurityService security, ILogger<AuthController> logger)
    {
        _security = security;
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

    public async Task<IActionResult> ProcessLogin(IFormCollection collection) 
    {
        var result = _security.authenticateUser(collection?["userName"]!, collection?["password"]!);

        if (result == null) {
            return View("LoginFailureTest");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, result.userName),
            new Claim("Fullname",  result.FirstName + result.LastName),
            new Claim(ClaimTypes.Role, "Administrator"),
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties {
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(15),
            IsPersistent = false,
            IssuedUtc = DateTime.UtcNow
        };

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
       
        _logger.LogInformation("User {Staff} logged in at {Time}.", result.userName, DateTime.UtcNow);

        return View("LoginSuccessTest");
    }

    public async Task<IActionResult> ProcessLogout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return View("Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

