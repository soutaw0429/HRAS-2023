using System.ComponentModel.DataAnnotations;

namespace HRAS_2023.Models
{
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
}
