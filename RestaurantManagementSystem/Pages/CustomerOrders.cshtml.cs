using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantManagementSystem.Pages
{
    public class CustomerOrdersModel : PageModel
    {
        private readonly UserService _userService;
        public List<Order> Orders { get; set; }

        public CustomerOrdersModel(UserService userService)
        {
            _userService = userService;

        }
        public IActionResult OnGet()
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Customer")
            {
                return RedirectToPage("/RoleSelection");
            }

            Orders = new List<Order>
            {
                new Order { OrderID = 1, OrderDate = DateTime.Now.AddDays(-5), Status = "Completed", TotalAmount = 29.99 },
                new Order { OrderID = 2, OrderDate = DateTime.Now.AddDays(-3), Status = "Pending", TotalAmount = 15.49 },
                new Order { OrderID = 3, OrderDate = DateTime.Now.AddDays(-1), Status = "Cancelled", TotalAmount = 0.00 },
               new Order { OrderID = 4, OrderDate = DateTime.Now.AddDays(-2), Status = "Completed", TotalAmount = 50.00 },
                 new Order { OrderID = 5, OrderDate = DateTime.Now.AddDays(-7), Status = "Pending", TotalAmount = 32.10 },
               new Order { OrderID = 6, OrderDate = DateTime.Now.AddDays(-8), Status = "Completed", TotalAmount = 99.99 }
            };
            return Page();
        }
        public IActionResult OnPostAddOrder(DateTime OrderDate, string Status, double TotalAmount)
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Customer")
            {
                return RedirectToPage("/RoleSelection");
            }
            Orders = new List<Order>
            {
                new Order { OrderID = 1, OrderDate = DateTime.Now.AddDays(-5), Status = "Completed", TotalAmount = 29.99 },
                new Order { OrderID = 2, OrderDate = DateTime.Now.AddDays(-3), Status = "Pending", TotalAmount = 15.49 },
                new Order { OrderID = 3, OrderDate = DateTime.Now.AddDays(-1), Status = "Cancelled", TotalAmount = 0.00 },
                 new Order { OrderID = 4, OrderDate = DateTime.Now.AddDays(-2), Status = "Completed", TotalAmount = 50.00 },
                 new Order { OrderID = 5, OrderDate = DateTime.Now.AddDays(-7), Status = "Pending", TotalAmount = 32.10 },
                 new Order { OrderID = 6, OrderDate = DateTime.Now.AddDays(-8), Status = "Completed", TotalAmount = 99.99 }
            };
            var newId = Orders.Max(r => r.OrderID) + 1;
            Orders.Add(new Order { OrderID = newId, OrderDate = OrderDate, Status = Status, TotalAmount = TotalAmount });
            return Page();
        }


        public IActionResult OnPostDeleteOrder(int OrderId)
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Customer")
            {
                return RedirectToPage("/RoleSelection");
            }
            Orders = new List<Order>
            {
                new Order { OrderID = 1, OrderDate = DateTime.Now.AddDays(-5), Status = "Completed", TotalAmount = 29.99 },
                new Order { OrderID = 2, OrderDate = DateTime.Now.AddDays(-3), Status = "Pending", TotalAmount = 15.49 },
                new Order { OrderID = 3, OrderDate = DateTime.Now.AddDays(-1), Status = "Cancelled", TotalAmount = 0.00 },
                 new Order { OrderID = 4, OrderDate = DateTime.Now.AddDays(-2), Status = "Completed", TotalAmount = 50.00 },
                 new Order { OrderID = 5, OrderDate = DateTime.Now.AddDays(-7), Status = "Pending", TotalAmount = 32.10 },
                 new Order { OrderID = 6, OrderDate = DateTime.Now.AddDays(-8), Status = "Completed", TotalAmount = 99.99 }
            };
            Orders.RemoveAll(o => o.OrderID == OrderId);

            return Page();
        }
        public class Order
        {
            public int OrderID { get; set; }
            public DateTime OrderDate { get; set; }
            public required string Status { get; set; }
            public double TotalAmount { get; set; }
        }
    }
}