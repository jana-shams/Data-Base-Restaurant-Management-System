using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.Services;
using System;
using System.Collections.Generic;


namespace RestaurantManagementSystem.Pages
{
    public class SecurityDashboardModel : PageModel
    {
        private readonly UserService _userService;
        public List<SecurityIncident> Incidents { get; set; }

        public SecurityDashboardModel(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Security")
            {
                return RedirectToPage("/RoleSelection");
            }

            Incidents = new List<SecurityIncident>
        {
            new SecurityIncident { IncidentID = 1, Description = "Unauthorized entry detected", Date = DateTime.Now.AddDays(-2), Status = "Resolved" },
            new SecurityIncident { IncidentID = 2, Description = "Suspicious package reported", Date = DateTime.Now.AddDays(-1), Status = "In Progress" }
        };
            return Page();
        }
    }

    public class SecurityIncident
    {
        public int IncidentID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}