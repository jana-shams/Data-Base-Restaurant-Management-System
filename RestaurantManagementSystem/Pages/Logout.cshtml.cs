using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.Services;

namespace RestaurantManagementSystem.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly UserService _userService;

        public LogoutModel(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            _userService.ClearUserSession();
            return Page();
        }
    }
}