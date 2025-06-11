using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Services;
using Microsoft.AspNetCore.Identity;
using RestaurantManagementSystem.Models;
using System.Threading.Tasks;


namespace RestaurantManagementSystem.Pages
{
    public class EmployeeSignUpModel : PageModel
    {
        private readonly RestaurantManagementContext _context;
        private readonly UserService _userService;

        public EmployeeSignUpModel(RestaurantManagementContext context, UserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [BindProperty]
        public required string Name { get; set; }

        [BindProperty]
        public required string Email { get; set; }

        [BindProperty]
        public required string Password { get; set; }

        [BindProperty]
        public required string Role { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var employee = new Employee
            {
                Name = Name,
                Role = Role,
                ContactInfo = Email
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            var userCredential = new UserCredential
            {
                UserID = employee.EmployeeID,
                UserType = employee.Role,
                HashedPassword = Password
            };
            _context.UserCredentials.Add(userCredential);
            await _context.SaveChangesAsync();

            _userService.SetUserSession(Role, employee.EmployeeID);

            TempData["Message"] = "Employee signed up successfully!";

            return RedirectToPage($"/{Role}Dashboard");
        }
    }
}