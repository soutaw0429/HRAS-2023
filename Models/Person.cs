namespace HRAS.Models;

using System.ComponentModel.DataAnnotations;

public class Person
{
    [Required]
    public int id {get; set;}

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
}