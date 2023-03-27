namespace HRAS.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Staff
{
    [Required]
    [Key]
    public int id {get; set;}

    [Required]
    [DataType(DataType.Date)]
    public int BirthDate {get; set;}

    [Required]
    [StringLength(50)]
    public string? FirstName {get; set;}

    [Required]
    // Changed by removing MaxLengthAttribute for Login test purposes only
    // [MaxLengthAttribute(1)]
    public char MiddleInitial {get; set;}

    [Required]
    [StringLength(50)]
    public string? LastName {get; set;}
    
    [Required]
    [Key]
    [StringLength(50)]
    public string? userName {get; set;}

    [Required]
    [DataType(DataType.Password)]
    public string? password {get; set;}

    [Required]
    [StringLength(50)]
    public string? userType {get; set;}

    [Required]
    [StringLength(50)]
    public string? position {get; set;}
}