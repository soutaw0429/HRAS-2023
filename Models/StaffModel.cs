namespace HRAS.Models;

using System.ComponentModel.DataAnnotations;

public class StaffModel
{
    [Required]
    public int id {get; set;}
    
    [Required]
    public string? userName {get; set;}

    [Required]
    [DataType(DataType.Password)]
    public string? password {get; set;}

    [Required]
    public string? position {get; set;}

    [Required]
    public char userType {get; set;}
}