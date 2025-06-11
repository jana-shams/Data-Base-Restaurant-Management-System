using System;
namespace RestaurantManagementSystem.Models
{
    public class SalesOrder
    {
        public int OrderID { get; set; }
        public required string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}