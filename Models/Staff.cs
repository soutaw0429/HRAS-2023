namespace HRAS.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Staff
{
    [Required]
    [Key]
    [StringLength(25)]
    public string userName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateOnly BirthDate {get; set;}

    [Required]
    [StringLength(20)]
    public string FirstName {get; set;}

    [Required]
    [MaxLengthAttribute(1)]
    public char MiddleInitial {get; set;}

    [Required]
    [StringLength(30)]
    public string LastName {get; set;}
    

    [Required]
    [DataType(DataType.Password)]
    [StringLength(50)]
    public string? password {get; set;}

    [Required]
    [StringLength(1)]
    public char userType {get; set;}
}