namespace HRAS_2023.Services;

using HRAS_2023.Logic;
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
            return _inventory.getItemByItemName(itemName);
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
}
