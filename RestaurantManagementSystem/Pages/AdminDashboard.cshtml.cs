using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.Services;
using RestaurantManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Pages
{
    public class AdminDashboardModel : PageModel
    {
        private readonly UserService _userService;
        private readonly RestaurantManagementContext _context;

        public int TotalUsers { get; set; }
        public AdminDashboardModel(UserService userService, RestaurantManagementContext context)
        {
            _userService = userService;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Admin")
            {
                return RedirectToPage("/RoleSelection");
            }
            TotalUsers = await _context.Customers.CountAsync() + await _context.Employees.CountAsync();
            return Page();
        }
    }
}