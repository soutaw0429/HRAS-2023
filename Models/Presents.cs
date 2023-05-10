namespace HRAS_2023.Models;

using System.ComponentModel.DataAnnotations;

public class Presents
{
    [Required]
    [Key]
    [StringLength(25)]
    public string? Symptom_Name { get; set; }

    [Required]
    [Key]
    [StringLength(9)]
    public int Patient_SSN { get; set; }

    [Required]
    [Key]
    [DataType(DataType.DateTime)]
    public DateTime VisitHistory_CheckInDateTime { get; set; }
}