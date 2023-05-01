namespace HRAS_2023.Models;

using System.ComponentModel.DataAnnotations;

public class Staff
{
    [Required]
    [Key]
    [StringLength(25)]
    public string? userName { get; set; }

    [Required]
    [StringLength(20)]
    public string? FirstName {get; set;}

    [Required]
    [StringLength(30)]
    public string? LastName {get; set;}
    
    [Required]
    [DataType(DataType.Password)]
    [StringLength(128)]
    public string? password {get; set;}

    [Required]
    [StringLength(1)]
    public char userType {get; set;}
}