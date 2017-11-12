using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAssist2.Common.Entities {
    public class TransactionItem {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Transaction")]
        public int TransactionId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Item")]
        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public int Amount { get; set; }

        // navigation properties
        public virtual Transaction Transaction { get; set; }

        public virtual Item Item { get; set; }
    }
}