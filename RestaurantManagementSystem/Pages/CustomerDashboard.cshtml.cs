using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.Services;

namespace RestaurantManagementSystem.Pages
{
    public class CustomerDashboardModel : PageModel
    {
        private readonly UserService _userService;

        public string CustomerName { get; set; }

        public CustomerDashboardModel(UserService userService)
        {
            _userService = userService;

        }

        public IActionResult OnGet()
        {

            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Customer")
            {
                return RedirectToPage("/RoleSelection");
            }

            CustomerName = "John Doe";
            return Page();
        }
    }
}