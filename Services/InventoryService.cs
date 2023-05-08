namespace HRAS.Services;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class InventoryService
{   
    public static decimal CalculateItemCost(string stockId, int count)
    {
        decimal itemPrice = 0;
        string connectionString = "Data Source=DESKTOP-UF88CHJ;Initial Catalog=HRASDatabase;Integrated Security=True";
    
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using(SqlCommand command = new SqlCommand("GetInventoryItemByStockID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StockId", stockId);

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    
                    if(!reader.HasRows)
                    {
                        throw new Exception("There is no such a item exists.");
                    } 
                      
                    if(reader.Read())
                    {
                        itemPrice = reader.GetDecimal(4);
                    }
                    reader.Close();    
                }
            }
        }

        return itemPrice*count;
    }

    public static string getStockIdByItemName(string itemName)
    {
        string itemId = "";
        string connectionString = "Data Source=DESKTOP-UF88CHJ;Initial Catalog=HRASDatabase;Integrated Security=True";
    
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using(SqlCommand command = new SqlCommand("GetInventoryItemByName", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Description", itemName);

                using(SqlDataReader reader = command.ExecuteReader())
                { 
                    if(!reader.HasRows)
                    {
                        throw new Exception("There is no such a item exists.");
                    } 

                    if(reader.Read())
                    {
                        itemId = reader.GetString(0);
                    }
                    reader.Close();    
                }
            }
        }

        return itemId;
    }
    public static string getItemNameByStockId(string stockId)
    {
        string itemName = "";
        string connectionString = "Data Source=DESKTOP-UF88CHJ;Initial Catalog=HRASDatabase;Integrated Security=True";
    
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using(SqlCommand command = new SqlCommand("GetInventoryItemByStockID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StockId", stockId);

                using(SqlDataReader reader = command.ExecuteReader())
                { 
                    if(!reader.HasRows)
                    {
                        throw new Exception("There is no such a item exists.");
                    } 

                    if(reader.Read())
                    {
                        itemName = reader.GetString(2);
                    }
                    reader.Close();    
                }
            }
        }

        return itemName;
    }

    public static decimal CalculateTotalInventoryCost(Dictionary<string, decimal> itemDictionary)
    {
        decimal totalInventoryCost = 0;
         foreach(var str in itemDictionary)
        {
            totalInventoryCost += str.Value;
        }
        return totalInventoryCost;
    }
}
