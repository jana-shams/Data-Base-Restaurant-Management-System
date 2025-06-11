using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.Services;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RestaurantManagementSystem.Pages
{
    public class SalesDashboardModel : PageModel
    {
        private readonly UserService _userService;
        private readonly RestaurantManagementContext _context;
        public double TotalSales { get; set; }
        public double AvgOrderValue { get; set; }
        public List<SalesOrder> Orders { get; set; }

        public SalesDashboardModel(UserService userService, RestaurantManagementContext context)
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
            TotalSales = 12345.67;
            AvgOrderValue = 45.23;

            Orders = await _context.Orders
                    .Include(o => o.Customer)
                    .Select(o => new SalesOrder
                    {
                        OrderID = o.OrderID,
                        CustomerName = o.Customer != null ? o.Customer.Name : "Guest",
                        TotalAmount = o.TotalAmount,
                        OrderDate = o.OrderDate
                    })
                .ToListAsync();
            return Page();
        }
    }
}