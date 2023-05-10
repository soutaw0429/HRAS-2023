namespace HRAS_2023.Models;

using System.ComponentModel.DataAnnotations;

public class StaysIn
{
    [Required]
    [Key]
    [StringLength(1)]
    public char isAdmitted { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime leftTheRoomDateTime { get; set; }

    [Required]
    [Key]
    [StringLength(30)]
    public string? room_building_name { get; set; }

    [Required]
    [Key]
    [StringLength(9)]
    public string? room_number { get; set; }

    [Required]
    [Key]
    [StringLength(9)]
    public string? visitHistory_patientSSN { get; set; }

    [Required]
    [Key]
    [DataType(DataType.DateTime)]
    public DateTime visitHistory_checkInDateTime { get; set; }
}