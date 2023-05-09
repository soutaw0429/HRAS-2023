namespace HRAS_2023.Interfaces;

using HRAS_2023.Models;
using HRAS.Services;
public interface IInventoryLogic
{
    InventoryItem? getItemByStockId(string stockId);
    InventoryItem? getItemByName(string itemName);
}
