namespace HRAS.Models;

using System.ComponentModel.DataAnnotations;

public class PersonModel
{
    [Required]
    public int id {get; set;}

    [Required]
    public int SSN {get; set;}

    [Required]
    public string? firstName {get; set;}

    [Required]
    public string? middleInitial {get; set;}

    [Required]
    public string? lastName {get; set;}

    [Required]
    public char sex {get; set;}

    [Required]
    [DataType(DataType.Date)]
    public int birthdate {get; set;}

    [Required]
    public string? insurer {get; set;}

    [Required]
    [DataType(DataType.MultilineText)]
    public string? streetAddress {get; set;}

    [Required]
    public string? city {get; set;}

    [Required]
    public string? state {get; set;}

    [Required]
    [DataType(DataType.PostalCode)]
    public int ZIP {get; set;}

}