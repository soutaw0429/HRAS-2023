namespace HRAS_2023.Logic;

using HRAS_2023.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using HRAS_2023.Context;
using HRAS_2023.Interfaces;

public class InventoryLogic : IInventoryLogic
{

    private readonly HrasDbContext _context;

    public InventoryLogic(HrasDbContext context)
    {
        _context = context;
    }

    public Inventory? getItemByItemName(string itemName)
    {
        var inventoryParam = new SqlParameter("@Description", itemName);
        return _context.Inventory.FromSqlRaw("EXEC GetInventoryItemByName @Description", inventoryParam).AsEnumerable().First();
    }
    
    public Inventory? getItemByStockId(string stockId)
    {
        var inventoryParam = new SqlParameter("@StockId", stockId);
        return _context.Inventory.FromSqlRaw("EXEC GetInventoryItemByName @StockId", inventoryParam).AsEnumerable().FirstOrDefault();
    } 
}