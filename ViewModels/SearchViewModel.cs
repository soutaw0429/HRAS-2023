namespace HRAS_2023.ViewModels;

using HRAS_2023.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[Keyless]
public class SearchViewModel
{
    //[ForeignKey(nameof(Patient))]
    public Patient? Patient { get; set; }

    public Home? Home { get; set; }

    public List<Patient>? Patients { get; set; } = new List<Patient> ();

    public List<Home>? Homes { get; set; }

    [NotMapped]
    public StaysIn? StaysIn { get; set; }
    //[NotMapped]
    //public VisitHistory? VisitHistory { get; set; }
}
