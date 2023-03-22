namespace HRAS.Models;

using System.ComponentModel.DataAnnotations;

//seems like this class will be unnecessary since the DB does not have Person entity type. 
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