namespace HRAS_2023.Models;

using System.ComponentModel.DataAnnotations;

public class VisitHistory
{
    [Required]
    [Key]
    [StringLength(9)]
    public string? patient_SSN { get; set; }

    [Required]
    [Key]
    [DataType(DataType.DateTime)]
    public DateTime CheckInDateTime { get; set; }

    [Required]
    [StringLength(75)]
    public string? Diagnosis { get; set; }

    [Required]
    [StringLength(100)]
    public string? Notes { get; set; }
}
