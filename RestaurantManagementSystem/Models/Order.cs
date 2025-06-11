using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementSystem.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalAmount { get; set; }
        [Required]
        public required string Status { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer? Customer { get; set; } // Navigation property
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
        public virtual Delivery? Delivery { get; set; }
        public virtual KitchenTicket? KitchenTicket { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
        public string? CustomerName { get; set; }
    }
}