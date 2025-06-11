using System;

namespace RestaurantManagementSystem.ViewModels
{
    public class CustomerReservationViewModel
    {
        public int ReservationID { get; set; }
        public DateTime ReservationDate { get; set; }
        public int CustomerID { get; set; }
        public int NumberOfPeople { get; set; }
    }
}