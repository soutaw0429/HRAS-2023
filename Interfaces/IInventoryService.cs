namespace HRAS_2023.Interfaces;

using HRAS_2023.Models;

public interface IInventoryService
{
    InventoryItem? getInventoryItem(string stockId, string itemName);
}