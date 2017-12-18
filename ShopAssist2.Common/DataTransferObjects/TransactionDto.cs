using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ShopAssist2.Common.DataTransferObjects {
    [DataContract(Name = "transaction")]
    public class TransactionDto {
        [DataMember(Name = "transactionId")]
        public int TransactionId { get; set; }

        [DataMember(Name = "transactionType")]
        public int TransactionType { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "items")]
        public ICollection<ItemDto> Items { get; set; }

    }
}