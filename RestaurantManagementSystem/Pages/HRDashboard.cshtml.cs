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
    public class HRDashboardModel : PageModel
    {
        private readonly UserService _userService;
        private readonly RestaurantManagementContext _context;

        public int TotalEmployees { get; set; }
        public List<Employee> Employees { get; set; }

        public HRDashboardModel(UserService userService, RestaurantManagementContext context)
        {
            _userService = userService;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "HR")
            {
                return RedirectToPage("/RoleSelection");
            }

            TotalEmployees = await _context.Employees.CountAsync();
            Employees = await _context.Employees.ToListAsync();
            return Page();
        }
    }
}