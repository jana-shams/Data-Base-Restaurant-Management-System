namespace RestaurantManagementSystem.Models
{
    public class ServerOrder
    {
        public int OrderID { get; set; }
        public required string MenuItem { get; set; }
        public required string Status { get; set; }
    }
}