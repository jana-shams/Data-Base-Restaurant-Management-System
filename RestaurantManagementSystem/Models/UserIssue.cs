namespace RestaurantManagementSystem.Models
{
    public class UserIssue
    {
        public int IssueID { get; set; }
        public required string User { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
    }
}