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
    public class MenuPageModel : PageModel
    {
        private readonly UserService _userService;
        private readonly RestaurantManagementContext _context;
        public List<MenuItem> MenuItems { get; set; }

        [BindProperty]
        public MenuItem NewMenuItem { get; set; }

        public MenuPageModel(UserService userService, RestaurantManagementContext context)
        {
            _userService = userService;
            _context = context;
            NewMenuItem = new MenuItem { Name = "", Description = "", Category = "", ImageUrl = "", Price = 0 };

        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!_userService.IsUserAuthenticated())
            {
                return RedirectToPage("/RoleSelection");
            }
            if (_userService.GetUserType() != "Customer" && _userService.GetUserType() != "Manager")
            {
                return RedirectToPage("/RoleSelection");
            }
            MenuItems = await _context.MenuItems.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAddMenuItemAsync()
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Manager")
            {
                return RedirectToPage("/RoleSelection");
            }

            if (!ModelState.IsValid)
            {
                MenuItems = await _context.MenuItems.ToListAsync();
                return Page();
            }

            _context.MenuItems.Add(NewMenuItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("/MenuPage");
        }
        public async Task<IActionResult> OnPostDeleteMenuItemAsync(int menuItemId)
        {
            if (!_userService.IsUserAuthenticated() || _userService.GetUserType() != "Manager")
            {
                return RedirectToPage("/RoleSelection");
            }

            var menuItem = await _context.MenuItems.FindAsync(menuItemId);
            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/MenuPage");
        }
    }
}