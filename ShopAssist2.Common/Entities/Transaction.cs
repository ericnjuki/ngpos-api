using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopAssist2.Common.Enums;

namespace ShopAssist2.Common.Entities {
    public class Transaction {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        [Required]
        public DateTime Date { get; set; }


        //Complex Property Items
        [Required]
        public virtual ICollection<TransactionItem> TransactionItems { get; set; }


    }
}