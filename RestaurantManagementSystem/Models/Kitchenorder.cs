namespace RestaurantManagementSystem.Models
{
    public class KitchenOrder
    {
        public int OrderID { get; set; }
        public required string MenuItem { get; set; }
        public required string Status { get; set; }
    }
}