using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.Services;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace RestaurantManagementSystem.Pages
{
    public class ManagerDashboardModel : PageModel
    {
        private readonly UserService _userService;
        private readonly RestaurantManagementContext _context;
        public List<Employee> Employees { get; set; }
        public double TotalProfit { get; set; }

        public ManagerDashboardModel(UserService userService, RestaurantManagementContext context)
        {
            _userService = userService;
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Manager")
            {
                return RedirectToPage("/RoleSelection");
            }
            Employees = await _context.Employees.ToListAsync();
            TotalProfit = 10560.75;
            return Page();
        }
    }
}