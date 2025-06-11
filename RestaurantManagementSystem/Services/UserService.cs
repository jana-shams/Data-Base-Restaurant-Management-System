using Microsoft.AspNetCore.Http;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Services
{
    public class UserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetUserSession(string userType, int userId)
        {
            _httpContextAccessor.HttpContext.Session.SetString("UserType", userType);
            _httpContextAccessor.HttpContext.Session.SetInt32("UserId", userId);

        }

        public string? GetUserType()
        {
            return _httpContextAccessor.HttpContext.Session.GetString("UserType");
        }
        public int? GetUserId()
        {
            return _httpContextAccessor.HttpContext.Session.GetInt32("UserId");
        }

        public bool IsUserAuthenticated()
        {
            return GetUserType() != null;
        }
        public void ClearUserSession()
        {
            _httpContextAccessor.HttpContext.Session.Remove("UserType");
            _httpContextAccessor.HttpContext.Session.Remove("UserId");

        }

    }
}