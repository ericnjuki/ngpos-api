using System.Runtime.Serialization;

namespace ShopAssist2.Common.DataTransferObjects {
    [DataContract(Name = "transactionItem")]
    public class TransactionItemDto {
        [DataMember(Name = "transactionId")]
        public int TransactionId { get; set; }

        [DataMember(Name = "itemId")]
        public int ItemId { get; set; }

        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }

        [DataMember(Name = "amount")]
        public int Amount { get; set; }

    }
}
