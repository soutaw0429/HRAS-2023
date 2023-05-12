namespace HRAS_2023.ViewModels;

using HRAS_2023.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[Keyless]
public class InventoryViewModel
{
	public Inventory? Inventory { get; set; }

	public Dictionary<string, int> Cart = new Dictionary<string, int>();
}
