using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementSystem.Models
{
    public class PromotionDetail
    {
        [Required]
        public int PromotionID { get; set; }
        [Required]
        public int MenuItemID { get; set; }

        [ForeignKey("PromotionID")]
        public virtual Promotion? Promotion { get; set; }

        [ForeignKey("MenuItemID")]
        public virtual MenuItem? MenuItem { get; set; }
    }
}