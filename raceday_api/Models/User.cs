using System.ComponentModel.DataAnnotations;
namespace raceday_api.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = "";

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = "";

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = "";

        [Required]
        public string PasswordHash { get; set; } = "";

        [MaxLength(20)]
        public string? Phone { get; set; }

        [Required]
        public string Role { get; set; } = "Participant";

        public string? ProfilePictureUrl { get; set; }

        public DateTime CreatedAt { get; set; } =
            DateTime.UtcNow;

    }
}
