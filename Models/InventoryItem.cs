namespace HRAS_2023.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

public class InventoryItem
{
    [Required]
    [Key]
    [StringLength(5)]
    public char? stock_id { get; set; }

    [Required]
    [StringLength(5)]
    public string? quantity { get; set; }

    [Required]
    [StringLength(35)]
    public string? description { get; set; }

    [Required]
    public int? size { get; set; }

    [Required]
    [NotMapped]
    public SqlMoney? price { get; set; }
}
