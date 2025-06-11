using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.Services;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RestaurantManagementSystem.Pages
{
    public class ServerDashboardModel : PageModel
    {
        private readonly UserService _userService;
        private readonly RestaurantManagementContext _context;
        public List<ServerOrder> Orders { get; set; }

        public ServerDashboardModel(UserService userService, RestaurantManagementContext context)
        {
            _userService = userService;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Server")
            {
                return RedirectToPage("/RoleSelection");
            }
            Orders = await _context.KitchenTickets
                   .Include(k => k.Order)
                    .ThenInclude(o => o.OrderDetails)
                    .ThenInclude(od => od.MenuItem)
                    .Select(k => new ServerOrder
                    {
                        OrderID = k.OrderID,
                        MenuItem = k.Order.OrderDetails.First().MenuItem.Name,
                        Status = k.Status
                    })
               .ToListAsync();
            return Page();
        }
    }
}