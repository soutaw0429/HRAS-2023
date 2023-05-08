namespace HRAS_2023.Models;

using System.ComponentModel.DataAnnotations;

public class Home
{
    [Required]
    [Key]
    [StringLength(35)]
    public string? StreetAddress_Line_1 { get; set; }

    [Required]
    [StringLength(35)]
    public string? StreetAddress_Line_2 { get; set; }

    [Required]
    [StringLength(25)]
    public string? City { get; set; }

    [Required]
    [StringLength(2)]
    public char? State { get; set; }

    [Required]
    [StringLength(5)]
    public string? ZIP { get; set; }
}