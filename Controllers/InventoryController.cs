namespace HRAS_2023.Controllers; 

using Microsoft.AspNetCore.Mvc; 
public class InventoryController : Controller 
{
    public IActionResult Index() 
    {
        return View(); 
    }
}
