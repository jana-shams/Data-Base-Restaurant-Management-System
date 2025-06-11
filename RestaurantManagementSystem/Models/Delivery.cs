using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementSystem.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryID { get; set; }
        [Required]
        public required string DeliveryAddress { get; set; }
        [Required]
        public required string Status { get; set; }
        [Required]
        public int OrderID { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order? Order { get; set; }
    }
}