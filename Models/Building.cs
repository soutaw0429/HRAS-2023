namespace HRAS_2023.Models;

using System.ComponentModel.DataAnnotations;

public class Building
{
    private string? name;

    [Required]
    [Key]
    public string Name 
    { 
        get { return name!; } 
        set { name = value; } 
    }

}
