using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

public class ReservationsPageModel : PageModel
{
    public List<Reservation> Reservations { get; set; }

    public void OnGet()
    {
        Reservations = new List<Reservation>
        {
            new Reservation { ReservationID = 1, CustomerName = "John Doe", ReservationDate = DateTime.Now.AddDays(2), NumberOfPeople = 4 },
            new Reservation { ReservationID = 2, CustomerName = "Jane Smith", ReservationDate = DateTime.Now.AddDays(5), NumberOfPeople = 2 },
            new Reservation { ReservationID = 3, CustomerName = "Bob Brown", ReservationDate = DateTime.Now.AddDays(7), NumberOfPeople = 6 }
        };
    }
}

public class Reservation
{
    public int ReservationID { get; set; }
    public string CustomerName { get; set; }
    public DateTime ReservationDate { get; set; }
    public int NumberOfPeople { get; set; }
}
