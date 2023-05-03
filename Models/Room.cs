namespace HRAS_2023.Models;

using System.ComponentModel.DataAnnotations;

public class Room
{
    private string? roomNumber;
    private string? designation;
    private int maxOccupancy;
    private long hourlyRate; //in the Spec Doc, the hourlyRate is int. Isn't long better?
    private Building? building;
    private string? floor;
    private string? wing;
    

    //[Required(ErrorMessage = "Specify the Room Number")]
    [Required]
    [Key]
    [StringLength(9)]
    public string RoomNumber
    {
        get { return roomNumber!; }
        set { roomNumber = value; }
    }

    [Required]
    public string Designation
    {
        get { return designation!; }
        set { designation = value; }
    }

    [Required]
    public int MaxOccupancy
    {
        get { return maxOccupancy; }
        set { maxOccupancy = value; }
    }

    [Required]
    public long HourlyRate
    {
        get { return hourlyRate; }
        set { hourlyRate = value; }
    }

    [Required]
    public string Floor
    {
        get { return floor!; }
        set { floor = value; }
    }

    [Required]
    public string Wing
    {
        get { return wing!; }
        set { wing = value; }
    }

    [Required]
    public Building Building 
    {
        get { return building!; }
        set { building = value; }
    } 
}
