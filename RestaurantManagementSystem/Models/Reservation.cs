using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }
        [Required]
        public int NumberOfPeople { get; set; }
    }
}