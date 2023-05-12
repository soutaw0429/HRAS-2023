namespace HRAS_2023.Interfaces;

using HRAS_2023.Models;
public interface IInventoryLogic
{
    Inventory? getItemByStockId(string stockId);
    Inventory? getItemByItemName(string itemName);
}
