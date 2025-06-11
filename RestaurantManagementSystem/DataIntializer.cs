using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Data;
using RestaurantManagementSystem.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Helpers
{
    public static class DataInitializer
    {


        public static async Task Initialize(RestaurantManagementContext context)
        {
            if (context.UserCredentials.Any())
            {
                return; // DB has been seeded
            }

            // Add User Credentials for Customers
            var customers = await context.Customers.ToListAsync();
            foreach (var customer in customers)
            {
                var passwordHasher = new PasswordHasher<Customer>();
                string hashedPassword = passwordHasher.HashPassword(null, "DefaultPassword");
                var userCredential = new UserCredential
                {
                    UserID = customer.CustomerID,
                    UserType = "Customer",
                    HashedPassword = hashedPassword
                };
                context.UserCredentials.Add(userCredential);
            }
            // Add User Credentials for Employees
            var employees = await context.Employees.ToListAsync();
            foreach (var employee in employees)
            {
                var passwordHasher = new PasswordHasher<Employee>();
                string hashedPassword = passwordHasher.HashPassword(null, "DefaultPassword");
                var userCredential = new UserCredential
                {
                    UserID = employee.EmployeeID,
                    UserType = employee.Role,
                    HashedPassword = hashedPassword
                };
                context.UserCredentials.Add(userCredential);
            }

            await context.SaveChangesAsync();
        }
    }
}