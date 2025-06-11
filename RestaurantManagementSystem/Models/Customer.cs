using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        // Navigation property for related Orders
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Reservation>? Reservations { get; set; }
    }
}