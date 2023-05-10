namespace HRAS_2023.Interfaces;

using HRAS_2023.Models;
public interface IInventoryLogic
{
    InventoryItem? getItemByStockId(string stockId);
    InventoryItem? getItemByItemName(string itemName);
}
