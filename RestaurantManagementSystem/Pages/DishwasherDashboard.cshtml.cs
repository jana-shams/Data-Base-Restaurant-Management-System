using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.Services;
using System.Collections.Generic;

namespace RestaurantManagementSystem.Pages
{
    public class DishwasherDashboardModel : PageModel
    {
        private readonly UserService _userService;
        public List<DishwashingTask> Tasks { get; set; }

        public DishwasherDashboardModel(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Dishwasher")
            {
                return RedirectToPage("/RoleSelection");
            }

            Tasks = new List<DishwashingTask>
        {
            new DishwashingTask { TaskID = 1, Description = "Clean dishes from table 5" },
            new DishwashingTask { TaskID = 2, Description = "Wash pots from order 12" },
            new DishwashingTask { TaskID = 3, Description = "Sanitize kitchen utensils" }
        };
            return Page();
        }
    }

    public class DishwashingTask
    {
        public int TaskID { get; set; }
        public string Description { get; set; }
    }
}