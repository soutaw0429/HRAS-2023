namespace HRAS_2023.Controllers; 

using HRAS_2023.Services;
using Microsoft.AspNetCore.Mvc; 
using HRAS_2023.Interfaces;
using HRAS_2023.ViewModels;
using Microsoft.IdentityModel.Tokens;
public class InventoryController : Controller 
{
    private readonly IInventoryService _inventory;
    private readonly ILogger<InventoryController> _logger;
    public InventoryController(IInventoryService inventoryService, ILogger<InventoryController> logger)
    {
        _inventory = inventoryService;
         _logger = logger;
    }
    public IActionResult Index() 
    {
        return View(); 
    }
    
    
    [HttpPost("/inventoryDeployment")]
    [Route("/inventoryDeployment")]
    public async Task<IActionResult> AssignToPatient()
    {
        decimal totalPrice = 0;
        // Retrieve values from the form
        Dictionary<string, decimal> itemDictionary = new Dictionary<string, decimal>();
        string stockId = Request.Form["stock_id"];
        string name = Request.Form["item_name"];
        int quantity = Convert.ToInt32(Request.Form["item_count"]);
        string nextAction = Request.Form["action"];

        if(nextAction == "AssignToPatient")
        {
            Console.WriteLine(CalculateTotalInventoryCost(itemDictionary));
            return Ok();
        }

        // Store values in a dictionary        
        totalPrice = CalculateItemCost(stockId, name, quantity);
        itemDictionary.Add(stockId, totalPrice);
        // Return a success response
        await Task.Delay(1000);
        return Ok();
    }

    public decimal CalculateItemCost(string stockId, string itemName, int count)
    {
        decimal itemPrice = _inventory.getInventoryItem(stockId,itemName).Price;
        return itemPrice*count;
    }

     public decimal CalculateTotalInventoryCost(Dictionary<string, decimal> itemDictionary)
    {
        decimal totalInventoryCost = 0;
         foreach(var str in itemDictionary)
        {
            totalInventoryCost += str.Value;
        }
        return totalInventoryCost;
    }
}
