namespace HRAS_2023.Controllers; 

using HRAS_2023.Services;
using Microsoft.AspNetCore.Mvc; 
using HRAS_2023.Interfaces;
using HRAS_2023.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Authorization;

//[Authorize(Policy = "Admin,Junior,Senior")]
[Authorize(Policy = "Admin")]
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
        SqlMoney? totalPrice = 0;
        // Retrieve values from the form
        Dictionary<string, SqlMoney?> itemDictionary = new Dictionary<string, SqlMoney?>();
        string stockId = Request.Form["stock_id"]!;
        string name = Request.Form["item_name"]!;
        int quantity = Convert.ToInt32(Request.Form["item_count"]);
        string nextAction = Request.Form["action"]!;

        if(nextAction == "AssignToPatient")
        {
            Console.WriteLine(CalculateTotalInventoryCost(itemDictionary));
            return Ok();
        }

        // Store values in a dictionary        
        totalPrice = CalculateItemCost(stockId, name, quantity)!;
        itemDictionary.Add(stockId, totalPrice);
        // Return a success response
        await Task.Delay(1000);
        return Ok();
    }

    public SqlMoney? CalculateItemCost(string stockId, string itemName, int count)
    {
        SqlMoney? itemPrice = _inventory.getInventoryItem(stockId,itemName)?.price!;
        return itemPrice*count;
    }

     public SqlMoney? CalculateTotalInventoryCost(Dictionary<string, SqlMoney?> itemDictionary)
    {
        SqlMoney? totalInventoryCost = 0;
         foreach(var str in itemDictionary)
        {
            totalInventoryCost = totalInventoryCost + str.Value;
        }
        return totalInventoryCost;
    }
}
