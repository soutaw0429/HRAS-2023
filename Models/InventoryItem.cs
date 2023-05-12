namespace HRAS_2023.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

public class Inventory
{
    [Required]
    [Key]
    [StringLength(5)]
    public string? stock_id { get; set; }

    [Required]
    [StringLength(5)]
    public string? quantity { get; set; }

    [Required]
    [StringLength(35)]
    public string? description { get; set; }

    [Required]
    public int? size { get; set; }

    [Required]
    public decimal? price { get; set; }
}
