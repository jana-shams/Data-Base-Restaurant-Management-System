using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Models;
using System.Threading.Tasks;
using RestaurantManagementSystem.Services;


namespace RestaurantManagementSystem.Pages
{
    public class CustomerSignUpModel : PageModel
    {
        private readonly RestaurantManagementContext _context;
        private readonly UserService _userService;


        public CustomerSignUpModel(RestaurantManagementContext context, UserService userService)
        {
            _context = context;
            _userService = userService;

        }


        [BindProperty]
        public required string Name { get; set; }

        [BindProperty]
        public required string Phone { get; set; }

        [BindProperty]
        public string? Email { get; set; }

        [BindProperty]
        public required string Password { get; set; }



        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customer = new Customer
            {
                Name = Name,
                Phone = Phone,
                Email = Email,
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            var userCredential = new UserCredential
            {
                UserID = customer.CustomerID,
                UserType = "Customer",
                HashedPassword = Password
            };
            _context.UserCredentials.Add(userCredential);
            await _context.SaveChangesAsync();

            _userService.SetUserSession("Customer", customer.CustomerID);

            TempData["Message"] = "Customer signed up successfully!";


            return RedirectToPage("/CustomerDashboard");
        }
    }
}