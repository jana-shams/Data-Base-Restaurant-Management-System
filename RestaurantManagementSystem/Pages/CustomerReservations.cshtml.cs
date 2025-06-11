using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantManagementSystem.Pages
{
    public class CustomerReservationsModel : PageModel
    {
        private readonly UserService _userService;

        public List<Reservation> Reservations { get; set; }
        public CustomerReservationsModel(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Customer")
            {
                return RedirectToPage("/RoleSelection");
            }
            Reservations = new List<Reservation>
            {
                new Reservation { ReservationID = 1, ReservationDate = DateTime.Now.AddDays(2), NumberOfPeople = 4 },
                new Reservation { ReservationID = 2, ReservationDate = DateTime.Now.AddDays(5), NumberOfPeople = 2 },
                new Reservation { ReservationID = 3, ReservationDate = DateTime.Now.AddDays(-1), NumberOfPeople = 6 },
                 new Reservation { ReservationID = 4, ReservationDate = DateTime.Now.AddDays(7), NumberOfPeople = 5 },
                 new Reservation { ReservationID = 5, ReservationDate = DateTime.Now.AddDays(1), NumberOfPeople = 3 },
                 new Reservation { ReservationID = 6, ReservationDate = DateTime.Now.AddDays(8), NumberOfPeople = 1 }

            };
            return Page();
        }
        public IActionResult OnPostAddReservation(DateTime ReservationDate, int NumberOfPeople)
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Customer")
            {
                return RedirectToPage("/RoleSelection");
            }
            Reservations = new List<Reservation>
            {
                 new Reservation { ReservationID = 1, ReservationDate = DateTime.Now.AddDays(2), NumberOfPeople = 4 },
                new Reservation { ReservationID = 2, ReservationDate = DateTime.Now.AddDays(5), NumberOfPeople = 2 },
                new Reservation { ReservationID = 3, ReservationDate = DateTime.Now.AddDays(-1), NumberOfPeople = 6 },
                  new Reservation { ReservationID = 4, ReservationDate = DateTime.Now.AddDays(7), NumberOfPeople = 5 },
                 new Reservation { ReservationID = 5, ReservationDate = DateTime.Now.AddDays(1), NumberOfPeople = 3 },
                 new Reservation { ReservationID = 6, ReservationDate = DateTime.Now.AddDays(8), NumberOfPeople = 1 }
            };
            var newId = Reservations.Max(r => r.ReservationID) + 1;
            Reservations.Add(new Reservation { ReservationID = newId, ReservationDate = ReservationDate, NumberOfPeople = NumberOfPeople });
            return Page();
        }

        public IActionResult OnPostDeleteReservation(int ReservationId)
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Customer")
            {
                return RedirectToPage("/RoleSelection");
            }
            Reservations = new List<Reservation>
            {
                 new Reservation { ReservationID = 1, ReservationDate = DateTime.Now.AddDays(2), NumberOfPeople = 4 },
                new Reservation { ReservationID = 2, ReservationDate = DateTime.Now.AddDays(5), NumberOfPeople = 2 },
                new Reservation { ReservationID = 3, ReservationDate = DateTime.Now.AddDays(-1), NumberOfPeople = 6 },
                 new Reservation { ReservationID = 4, ReservationDate = DateTime.Now.AddDays(7), NumberOfPeople = 5 },
                 new Reservation { ReservationID = 5, ReservationDate = DateTime.Now.AddDays(1), NumberOfPeople = 3 },
                 new Reservation { ReservationID = 6, ReservationDate = DateTime.Now.AddDays(8), NumberOfPeople = 1 }
            };
            Reservations.RemoveAll(r => r.ReservationID == ReservationId);
            return Page();
        }
        public class Reservation
        {
            public int ReservationID { get; set; }
            public DateTime ReservationDate { get; set; }
            public int NumberOfPeople { get; set; }
        }
    }
}