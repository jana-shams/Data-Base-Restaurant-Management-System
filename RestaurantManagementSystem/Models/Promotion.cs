using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementSystem.Models
{
    public class Promotion
    {
        [Key]
        public int PromotionID { get; set; }
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal DiscountRate { get; set; }

        public virtual ICollection<PromotionDetail>? PromotionDetails { get; set; }
    }
}