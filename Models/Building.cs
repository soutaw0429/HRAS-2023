using System.ComponentModel.DataAnnotations;

namespace HRAS_2023.Models
{
    public class Building
    {
        private string name;

        [Required]
        [Key]
        public string Name 
        { 
            get { return name; } 
            set { name = value; } 
        }

    }
}
