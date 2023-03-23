namespace HRAS.Models;

using System.ComponentModel.DataAnnotations;

public class Patient
{
    [Required]
    public int id {get; set;}

    [Required]
    [Key]
    public int SSN {get; set;}
    
    [Required]
    public string? insurer {get; set;}

    [Required]
    [MaxLengthAttribute(2)]
    public char state {get; set;}

    [Required]
    [DataType(DataType.PostalCode)]
    public int ZIP {get; set;}

    [Required]
    public string? city {get; set;}

    [Required]
    [DataType(DataType.MultilineText)]
    public string? streetAddress {get; set;}
    
    [Required]
    public bool isCurrentlyCheckedIn { get; set; }
}