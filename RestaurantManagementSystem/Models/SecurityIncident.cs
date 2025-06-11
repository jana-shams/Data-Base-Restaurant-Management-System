using System;

namespace RestaurantManagementSystem.Models
{
    public class SecurityIncident
    {
        public int IncidentID { get; set; }
        public required string Description { get; set; }
        public DateTime Date { get; set; }
        public required string Status { get; set; }
    }
}