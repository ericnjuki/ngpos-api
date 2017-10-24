using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAssist2.Common.Entities
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(64)]
        public string ItemName { get; set; }

        [Required]
        public int PurchaseCost { get; set; }

        [Required]
        public int SellingPrice { get; set; }
    }
}