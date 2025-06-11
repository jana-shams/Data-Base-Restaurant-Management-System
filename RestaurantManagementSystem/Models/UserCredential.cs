using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementSystem.Models
{
    public class UserCredential
    {
        [Key]
        public int CredentialID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public required string UserType { get; set; }
        [Required]
        public required string HashedPassword { get; set; }

    }
}