using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.Services;
using RestaurantManagementSystem.Models;


namespace RestaurantManagementSystem.Pages
{
    public class OrdersPageModel : PageModel
    {
        private readonly UserService _userService;
        public List<Order> Orders { get; set; }
        public OrdersPageModel(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Server")
            {
                return RedirectToPage("/RoleSelection");
            }

            Orders = new List<Order>
        {
            new Order { OrderID = 1, CustomerName = "John Doe", Status = "Pending" ,TotalAmount = 29.99m },
            new Order { OrderID = 2, CustomerName = "Jane Smith", Status = "Completed", TotalAmount = 59.99m },
            new Order { OrderID = 3, CustomerName = "Jim Halpert", Status = "Cancelled", TotalAmount = 45.50m }
        };
            return Page();
        }
    }
}