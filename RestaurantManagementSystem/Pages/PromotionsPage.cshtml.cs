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
    public class PromotionsPageModel : PageModel
    {
        private readonly UserService _userService;
        private readonly RestaurantManagementContext _context;
        public List<Promotion> Promotions { get; set; }

        public PromotionsPageModel(UserService userService, RestaurantManagementContext context)
        {
            _userService = userService;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Customer")
            {
                return RedirectToPage("/RoleSelection");
            }

            Promotions = await _context.Promotions.ToListAsync();
            return Page();
        }
    }
}