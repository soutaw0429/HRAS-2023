namespace HRAS_2023.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Diagnoses
{
    [Required]
    [Key]
    [StringLength(9)]
    public string? Patient_SSN { get; set; }

    [Required]
    //[Key]
    [DataType(DataType.DateTime)]
    public DateTime CheckInDateTime { get; set; }

    [Required]
    [StringLength(50)]
    public string? Diagnosis_Name { get; set; }

    [Required]
    //[Key]
    [StringLength(25)]
    public string? Staff_UserName { get; set; }
}
