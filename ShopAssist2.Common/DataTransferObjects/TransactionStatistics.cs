using System.Runtime.Serialization;

namespace ShopAssist2.Common.DataTransferObjects {
    [DataContract(Name = "monthlyStats")]
    public class TransactionStatistics {
        [DataMember(Name = "month")]
        public int Month { get; set; }

        // selling price aggregate
        [DataMember(Name = "sales")]
        public int Sales { get; set; }

        // buying price aggregate
        [DataMember(Name = "purchaseCost")]
        public int PurchaseCost { get; set; }

        [DataMember(Name = "profitLoss")]
        public int ProfitLoss { get; set; }

        // all items bought aggregate (added only during stocking)
        [DataMember(Name = "purchases")]
        public int Purchases { get; set; }
    }
}
