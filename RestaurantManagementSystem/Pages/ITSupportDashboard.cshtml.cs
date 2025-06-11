using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.Services;
using System.Collections.Generic;

namespace RestaurantManagementSystem.Pages
{
    public class ITSupportDashboardModel : PageModel
    {
        private readonly UserService _userService;
        public List<UserIssue> Issues { get; set; }

        public ITSupportDashboardModel(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "ITSupport")
            {
                return RedirectToPage("/RoleSelection");
            }
            Issues = new List<UserIssue>
        {
            new UserIssue { IssueID = 1, User = "John Doe", Description = "Password reset required", Status = "Pending" },
            new UserIssue { IssueID = 2, User = "Jane Smith", Description = "Unable to login", Status = "Resolved" },
            new UserIssue { IssueID = 3, User = "Jim Halpert", Description = "System crash during report generation", Status = "In Progress" }
        };
            return Page();
        }
    }
    public class UserIssue
    {
        public int IssueID { get; set; }
        public string User { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}