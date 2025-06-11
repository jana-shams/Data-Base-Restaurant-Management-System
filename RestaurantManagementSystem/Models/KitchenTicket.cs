using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementSystem.Models
{
    public class KitchenTicket
    {
        [Key]
        public int TicketID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        public required string Status { get; set; }
        [ForeignKey("OrderID")]
        public virtual Order? Order { get; set; }
    }
}