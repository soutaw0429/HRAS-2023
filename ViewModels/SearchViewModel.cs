namespace HRAS_2023.ViewModels;

using HRAS_2023.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[Keyless]
public class SearchViewModel
{
    [ForeignKey(nameof(Patient))]
    public string? PatientSSN { get; set; }
    public Patient? Patient { get; set; }
    [NotMapped]
    public Home? Home { get; set; }
    [NotMapped]
    public StaysIn? StaysIn { get; set; }
    [NotMapped]
    public VisitHistory? VisitHistory { get; set; }
}
