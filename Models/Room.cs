using System.ComponentModel.DataAnnotations;

namespace HRAS_2023.Models
{
    public class Room : Building
    {
        private string roomNumber;
        private string designation;
        private int maxOccupancy;
        private long hourlyRate; //in the Spec Doc, the hourlyRate is int. Isn't long better?
        private int floor;
        private int wing;

        //[Required(ErrorMessage = "Specify the Room Number")]
        [Required]
        public string RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        [Required]
        public string Designation
        {
            get { return designation; }
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
        public int Floor
        {
            get { return floor; }
            set { floor = value; }
        }

        [Required]
        public int Wing
        {
            get { return wing; }
            set { wing = value; }
        }

        public Room(string _roomNumber, string _buildingName, string _designation, int _maxOccupancy, 
            long _hourlyRate, int _floor, int _wing) : base(_buildingName)
        {
            roomNumber = _roomNumber;
            //buildingName -> comes from the base class
            designation = _designation;
            maxOccupancy = _maxOccupancy;
            hourlyRate = _hourlyRate;
            floor = _floor;
            wing = _wing;
        }
    }
}
