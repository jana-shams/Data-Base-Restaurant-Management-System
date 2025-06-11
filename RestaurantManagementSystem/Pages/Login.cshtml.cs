using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.Services;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace RestaurantManagementSystem.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserService _userService;
        private readonly RestaurantManagementContext _context;
        private readonly ILogger<LoginModel> _logger;
        [BindProperty]
        public required string Username { get; set; }

        [BindProperty]
        public required string Password { get; set; }

        public LoginModel(UserService userService, RestaurantManagementContext context, ILogger<LoginModel> logger)
        {
            _userService = userService;
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError(string.Empty, "Invalid Username or Password");
                return Page();
            }
            _logger.LogInformation($"Attempting login for user: {Username}");
            // Attempt to login as a customer
            var customerCredential = await _context.UserCredentials
                .FirstOrDefaultAsync(uc => uc.UserType == "Customer" && _context.Customers.Any(c => c.Email == Username && c.CustomerID == uc.UserID) && uc.HashedPassword == Password);

            if (customerCredential != null)
            {
                _logger.LogInformation($"Customer login succesful");
                _userService.SetUserSession("Customer", customerCredential.UserID);
                return RedirectToPage("/CustomerDashboard");

            }


            var employeeCredential = await _context.UserCredentials
                 .FirstOrDefaultAsync(uc =>
                  _context.Employees.Any(e => e.ContactInfo == Username && e.EmployeeID == uc.UserID) && uc.UserType != "Customer" && uc.HashedPassword == Password
                  );


            if (employeeCredential != null)
            {

                _logger.LogInformation($"Employee login succesful");
                _userService.SetUserSession(employeeCredential.UserType, employeeCredential.UserID);
                return RedirectToPage($"/{employeeCredential.UserType}Dashboard");
            }

            _logger.LogWarning($"Login failed for username: {Username} user not found");
            ModelState.AddModelError(string.Empty, "Invalid Username or Password");
            return Page();
        }


        public IActionResult OnPostGuestLogin()
        {
            _userService.SetUserSession("Guest", 0);
            return RedirectToPage("/Index");
        }
    }
}