namespace HRAS_2023.Interfaces;

using HRAS_2023.Models;
using HRAS_2023.ViewModels;

public interface IInventoryService
{
    InventoryItem? getInventoryItem(string stockId, string itemName);
}