namespace HRAS_2023.Models;

using System.ComponentModel.DataAnnotations;
public class Modifies
{

    [Required]
    [Key]
    [StringLength(25)]
    public string? staff_key { get; set; }

    [Required]
    [Key]
    [StringLength(5)]
    public char? inventory_key { get; set; }

    [Required]
    [Key]
    [StringLength(9)]
    public string? VisitHistory_patient_SSN { get; set; }

    [Required]
    [Key]
    [DataType(DataType.DateTime)]
    public DateTime? VisitHistory_CheckInDateTime { get; set; }
}
