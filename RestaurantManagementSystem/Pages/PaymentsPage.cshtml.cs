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
    public class PaymentsPageModel : PageModel
    {
        private readonly UserService _userService;
        private readonly RestaurantManagementContext _context;
        public List<Payment> Payments { get; set; }
        public PaymentsPageModel(UserService userService, RestaurantManagementContext context)
        {
            _userService = userService;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Sales")
            {
                return RedirectToPage("/RoleSelection");
            }

            Payments = await _context.Payments
                     .Include(p => p.Order)
                    .ToListAsync();
            return Page();
        }
    }
}