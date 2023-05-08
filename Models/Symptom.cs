namespace HRAS_2023.Models;

using System.ComponentModel.DataAnnotations;

public class Symptom
{
    private string? symptom;

    [Key]
    public string SymptomName 
    {
        get { return symptom!; }
        set { symptom = value; } 
    }
}
