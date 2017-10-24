using System.ComponentModel.DataAnnotations;

namespace ShopAssist2.Common.Entities
{
    public class Stock
    {
        [Required]
        public Item StockItem { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}