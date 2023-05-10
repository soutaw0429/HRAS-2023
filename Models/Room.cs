namespace HRAS_2023.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

public class Room
{
    [Required]
    [Key]
    [StringLength(30)]
    public string? building_key { get; set; }

    [Required]
    //[Key]
    [StringLength(9)]
    public string? number { get; set; }

    [Required]
    [NotMapped]
    public SqlMoney? hourly_rate { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime? effective_date_time { get; set; }

    [Required]
    [StringLength(24)]
    public string? wing { get; set; }

    [Required]
    [StringLength(4)]
    public string? floor { get; set; }

    [Required]
    [StringLength(2)]
    public string? designation { get; set; }

    [Required]
    public int? max_occupancy { get; set; }
}
