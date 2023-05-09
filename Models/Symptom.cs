namespace HRAS_2023.Models;

using System.ComponentModel.DataAnnotations;

public class Symptom
{
    [Required]
    [Key]
    [StringLength(25)]
    public string? Name { get; set; }
}
