
namespace HRAS.Logic;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using Microsoft.Extensions.Logging;
//using System.Threading.Tasks;
//using System.Web;
using HRAS.Services;
using System;
using System.Data;
using System.Data.SqlClient;
public class InventoryLogic //: ControllerBase
{
    
    /*
    private readonly ILogger<InventoryLogic> _logger;
    public InventoryLogic(ILogger<InventoryLogic> logger)
    {
        _logger = logger;
        itemDictionary = new Dictionary<string, decimal>();
    }
    */


    //[HttpPost("/inventoryDeployment")]
    //[Route("/inventoryDeployment")]
    /*
    public async Task<IActionResult> GetItems()
    {
        decimal totalPrice = 0;
        // Retrieve values from the form
        stockId = Request.Form["stock_id"];
        name = Request.Form["item_name"];
        quantity = Convert.ToInt32(Request.Form["item_count"]);
        string nextAction = Request.Form["action"];

        if(nextAction == "AssignToPatient")
        {
            Console.WriteLine(CalculateTotalInventoryCost());
            return Ok();
        }

        // Store values in a dictionary        
        totalPrice = InventoryService.CalculateCost(stockId, name, quantity);
        itemDictionary.Add(stockId, totalPrice);
        // Return a success response
        await Task.Delay(1000);
        return Ok();
    }*/
    public static void Main()
    {
        string stockId = "";
        string itemName = "";
        int quantity = 0;
        Dictionary<string, decimal> itemDictionary = new Dictionary<string, decimal>(); 
        decimal totalPrice = 0;
        decimal totalInventoryCost = 0;

        while(true)
        {
            Console.Write("Add items? (y/n): ");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            char ans = keyInfo.KeyChar;
            Console.Write("\n");
            
            if(ans != 'y' && ans != 'n')
            {
                Console.WriteLine("Please enter again.");
                continue;
            }
            

            if(ans == 'n') break;
            Console.Write("Put the stock id: ");
            stockId = Console.ReadLine();

            Console.Write("Put item name: ");
            itemName = Console.ReadLine();

            if(!isValidStockId(stockId) && !isValidStockItemName(itemName))
            {
                Console.WriteLine("Both item name and stock id are not given. Please try it again");
                continue;
            }
            else if(!isValidStockId(stockId)) 
            {
                stockId = InventoryService.getStockIdByItemName(itemName);
                Console.WriteLine("Stock ID : " + stockId);
            }
            else if(!isValidStockItemName("Item name : " + itemName)) 
            {
                itemName = InventoryService.getItemNameByStockId(stockId);
                Console.WriteLine(itemName);
            }

            Console.Write("Put the number used: ");
            quantity = Console.ReadLine()[0];


            totalPrice = InventoryService.CalculateItemCost(stockId, quantity);
             Console.WriteLine(stockId + "(" + itemName +") : "+ "(Price) " + totalPrice/quantity + 
             " * (Count) " + quantity + " = " + "(Total Price) " + totalPrice);


            itemDictionary.Add(stockId, totalPrice);  
        }
        totalInventoryCost = InventoryService.CalculateTotalInventoryCost(itemDictionary);
        Console.WriteLine("Total Inventory Cost = " + totalInventoryCost);
        //return totalInventoryCost;
    }

    public static bool isValidStockId(string stockId)
    {
        if(stockId.Length > 0 && stockId.Length <= 5) return true;
        
        return false;
    }
    public static bool isValidStockItemName(string itemName)
    {
        if(itemName.Length > 0) return true;
        
        return false;
    }
}