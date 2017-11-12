using System.Runtime.Serialization;

namespace ShopAssist2.Common.DataTransferObjects {
    [DataContract(Name = "item")]
    public class ItemDto {
        [DataMember(Name = "itemId")]
        public int ItemId { get; set; }

        [DataMember(Name = "itemName")]
        public string ItemName { get; set; }

        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }

        [DataMember(Name = "purchaseCost")]
        public int PurchaseCost { get; set; }

        [DataMember(Name = "sellingPrice")]
        public int SellingPrice { get; set; }

    }
}