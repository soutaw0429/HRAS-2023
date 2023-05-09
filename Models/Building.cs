namespace HRAS_2023.Models;

using System.ComponentModel.DataAnnotations;

public class Building
{
    [Required]
    [Key]
    [StringLength(30)]
    public string? building_name { get; set; }
}
