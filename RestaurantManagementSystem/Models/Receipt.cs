using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementSystem.Models
{
    public class Receipt
    {
        [Key]
        public int ReceiptID { get; set; }
        [Required]
        public DateTime ReceiptDate { get; set; }

        [Required]
        public int PaymentID { get; set; }

        [ForeignKey("PaymentID")]
        public virtual Payment? Payment { get; set; } // Navigation property
    }
}