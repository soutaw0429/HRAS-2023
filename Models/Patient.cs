namespace HRAS_2023.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Patient
{
    [Required]
    [Key]
    [StringLength(9)]
    public string? SSN { get; set; }

    [Required]
    [StringLength(50)]
    public string? LastName { get; set; }

    [Required]
    [StringLength(25)]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(1)]
    public string? MiddleInitial { get; set; }

    [Required]
    [StringLength(1)]
    public char Sex { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime BirthDate { get; set; }
    
    [Required]
    [StringLength(5)]
    public string? Insurer {get; set;}

    [Required]
    [StringLength(1)]
    public string? OrganDonor { get; set; }

    [Required]
    [StringLength(1)]
    public string? DNR_Status { get; set; }
}