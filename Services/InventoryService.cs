namespace HRAS_2023.Services;

using HRAS_2023.Interfaces;
using HRAS_2023.Models;
using HRAS_2023.ViewModels;

public class InventoryService : IInventoryService 
{ 
    private readonly IInventoryLogic _inventory;

    public InventoryService(IInventoryLogic inventory)
    {
        _inventory = inventory;
    }

    public InventoryViewModel? addItemToCart(string? stock_id, string? description, int quantity)
    {
        InventoryViewModel? viewModel = new InventoryViewModel();
        Console.WriteLine(quantity);
		if (!isValidStockId(stock_id!) && !isValidStockItemName(description!)) {
            //throw new Exception("Both item name and stock id are not given. Please try it again");
            return null;
		}

		if (!isValidStockId(stock_id!)) {
            Inventory? item1 = _inventory.getItemByItemName(description!);
            viewModel.Cart = addItemToDict(item1!, quantity, viewModel?.Cart);
            return viewModel;
		}

		Inventory? item = _inventory.getItemByStockId(stock_id!);
		Dictionary<string, int> cart = addItemToDict(item, quantity, viewModel?.Cart);
        return viewModel;
	}

    private Dictionary<string, int> addItemToDict(Inventory? item, int quantity, Dictionary<string, int>? cart)
    {   
        cart?.Add(item?.description!, quantity!);
        return cart!;
    }
    
    public bool isValidStockId(string stockId)
    {
        if(!string.IsNullOrWhiteSpace(stockId) && stockId.Length > 0 && stockId.Length <= 5) return true;
        return false;
    }

    public bool isValidStockItemName(string itemName)
    {
        if (!string.IsNullOrWhiteSpace(itemName) && itemName.Length > 0) return true;
        return false;
    }
    public decimal CalculateItemCost(string stockId, string itemName, int count)
    {
        //    decimal itemPrice = Convert.ToDecimal(getInventoryItem(stockId, itemName)?.price!);
        //    return itemPrice*count;
        return 0;
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
