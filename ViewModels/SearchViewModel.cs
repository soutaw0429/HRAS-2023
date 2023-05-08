namespace HRAS_2023.ViewModels;

using HRAS_2023.Models;

public class SearchViewModel
{
    public Patient? Patient { get; set; }
    public Home? Home { get; set; }
    public Room? Room { get; set; }
    public VisitHistory? VisitHistory { get; set; }
}
