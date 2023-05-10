namespace HRAS.Services;
using HRAS.Logic;
//using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using HRAS_2023.Interfaces;
using HRAS_2023.Models;

public class InventoryService : IInventoryService 
{ 
    private readonly IInventoryLogic _inventory;

    public InventoryService(IInventoryLogic inventory)
    {
         _inventory = inventory;
    }  
    
    public InventoryItem? getInventoryItem(string stockId, string itemName)
    {
        if(!isValidStockId(stockId) && !isValidStockItemName(itemName))
        {
            throw new Exception("Both item name and stock id are not given. Please try it again");
        }
        if(!isValidStockId(stockId)) 
        {
            return _inventory.getItemByName(itemName);
        }
        return _inventory.getItemByStockId(stockId);
    }
    
    public bool isValidStockId(string stockId)
    {
        if(stockId.Length > 0 && stockId.Length <= 5) return true;
        
        return false;
    }
    public bool isValidStockItemName(string itemName)
    {
        if(itemName.Length > 0) return true;
        
        return false;
    }
     public decimal CalculateItemCost(string stockId, string itemName, int count)
    {
        decimal itemPrice = getInventoryItem(stockId,itemName).Price;
        return itemPrice*count;
    }

     public decimal? CalculateTotalInventoryCost(Dictionary<string, decimal> itemDictionary)
    {
        decimal totalInventoryCost = 0;
         foreach(var str in itemDictionary)
        {
            totalInventoryCost += str.Value;
        }
        return totalInventoryCost;
    }
}
