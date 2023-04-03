using System.ComponentModel.DataAnnotations;

namespace HRAS_2023.Models
{
    public class InventoryItem
    {
        private string? stockID;
        private int quantity;
        private string? description;
        private long price;
        //From Spec doc feedback: "you need an allowance for "virtual" inventory". 
        //What is that??

        [Required]
        [Key]
        [StringLength(5)]
        public string StockID
        {
            get { return stockID!; }
            set { stockID = value; }
        }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity can not be negative!")]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [Required]
        public string Description
        {
            get { return description!; }
            set { description = value; }
        }

        [Required]
        [Range(0, long.MaxValue, ErrorMessage = "Price can not be negative!")]
        public long Price
        {
            get { return price; }
            set { price = value; }
        }


     /*   public InventoryItem(string _stockID, int _quantity, string _description, long _price)
        {
            stockID = _stockID;
            quantity = _quantity; ;
            description = _description; 
            price = _price;
        }*/

    }
}
