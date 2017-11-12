using System.Runtime.Serialization;

namespace ShopAssist2.Common.DataTransferObjects {
    [DataContract(Name = "monthlyStats")]
    public class TransactionStatistics {
        [DataMember(Name = "month")]
        public int Month { get; set; }

        [DataMember(Name = "sales")]
        public int Sales { get; set; }

        [DataMember(Name = "purchases")]
        public int Purchases { get; set; }

        [DataMember(Name = "profitLoss")]
        public int ProfitLoss { get; set; }
    }
}
