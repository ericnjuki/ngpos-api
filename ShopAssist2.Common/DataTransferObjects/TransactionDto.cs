using System;
using ShopAssist2.Common.Entities;
using ShopAssist2.Common.Enums;

namespace ShopAssist2.Common.DataTransferObjects
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }

        public TransactionType TransactionType { get; set; }

        public DateTime Date { get; set; }

        public Item Commodity { get; set; }

        public int Quantity { get; set; }

        public int Amount { get; set; }
    }
}