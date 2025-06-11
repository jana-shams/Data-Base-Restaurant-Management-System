using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Role { get; set; }
        public string? ContactInfo { get; set; }
    }
}