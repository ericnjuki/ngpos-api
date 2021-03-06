﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAssist2.Common.Entities {
    public class Item {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(64)]
        public string ItemName { get; set; }

        public string Unit { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int PurchaseCost { get; set; }

        [Required]
        public int SellingPrice { get; set; }

        public string Aliases { get; set; }

        [Required]
        public int Deleted { get; set; }

        public DateTime? DeleteDate { get; set; }

        //Complex Property; Not needed when creating new item
        public virtual ICollection<TransactionItem> TransactionItems { get; set; }
    }
}