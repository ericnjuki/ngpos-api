using ShopAssist2.Common.Entities;

namespace ShopAssist2.Common.DataTransferObjects
{
    public class StockDto
    {
        public Item StockItem { get; set; }

        public int Quantity { get; set; }
    }
}