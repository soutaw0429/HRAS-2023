namespace HRAS.Models;

using System.ComponentModel.DataAnnotations;

public class PatientModel
{
    [Required]
    public int id {get; set;}
    
    [Required]
    public bool isCurrentlyCheckedIn { get; set; } 
}