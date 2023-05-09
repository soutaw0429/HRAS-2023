
namespace HRAS.Logic;
using HRAS_2023.Models;
using HRAS.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HRAS_2023.Context;
using HRAS_2023.Interfaces;

public class InventoryLogic 
{

    private readonly HrasDbContext _context;

    public InventoryLogic(HrasDbContext context)
    {
        _context = context;
    }

    public InventoryItem? getItemByItemName(string itemName)
    {
        var inventoryParam = new SqlParameter("@Description", itemName);
        return _context.InventoryItem.FromSqlRaw("EXEC GetInventoryItemByName @Description", inventoryParam).AsEnumerable().FirstOrDefault();
    }
    
    public InventoryItem? getItemByStockId(string stockId)
    {
        var inventoryParam = new SqlParameter("@StockId", stockId);
        return _context.InventoryItem.FromSqlRaw("EXEC GetInventoryItemByName @StockId", inventoryParam).AsEnumerable().FirstOrDefault();
    } 
}