using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RestaurantManagementSystem.Pages
{
    public class RoleSelectionModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(string role)
        {
            if (role == "Customer")
            {
                return RedirectToPage("/CustomerSignUp", new { userType = "Customer" });
            }
            else if (role == "Employee")
            {
                return RedirectToPage("/EmployeeSignUp", new { userType = "Employee" });
            }

            return Page();
        }
    }
}