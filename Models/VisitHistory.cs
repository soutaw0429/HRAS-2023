using HRAS.Models;
using System.ComponentModel.DataAnnotations;

namespace HRAS_2023.Models
{
    public class VisitHistory
    {
        private DateTime checkInDateTime;
        private DateTime checkOutDateTime;
        private List<InventoryItem> usedItems;
        private List<string> symptoms;
        private string diagnose;

        [Key]
        public DateTime CheckInDateTime
        {
            get { return checkInDateTime; }
            set { checkInDateTime = value; }
        }

        public DateTime CheckOutDateTime
        {
            get { return checkOutDateTime; }
            set { checkOutDateTime = value; }        
        }

        public List<InventoryItem> UsedItems
        {
            get { return usedItems; }
            set { usedItems = value; }
        }
/*
        public List<string> Symptoms
        {
            get { return symptoms; }
            set { symptoms = value; }
        }
*/
        public string Diagnose
        {
            get { return diagnose; }
            set { diagnose = value; }
        }
    }
}
