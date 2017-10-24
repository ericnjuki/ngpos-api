using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAssist2.Common.DataTransferObjects
{
    public class ItemDto
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int PurchaseCost { get; set; }

        public int SellingPrice { get; set; }
    }
}