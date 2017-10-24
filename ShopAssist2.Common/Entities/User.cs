using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAssist2.Common.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }


        [Required]
        [MaxLength(32)]
        public string Username { get; set; }


        [Required]
        [MaxLength(512)]
        public string PasswordHash { get; set; }
    }
}