using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementSystem.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemID { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        public string? Category { get; set; }

        // Navigation property for related order details
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
        public virtual ICollection<PromotionDetail>? PromotionDetails { get; set; }
        public string? ImageUrl { get; set; }
    }
}