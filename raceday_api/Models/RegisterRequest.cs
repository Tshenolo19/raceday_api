using System.ComponentModel.DataAnnotations;
namespace raceday_api.Models
{
    public class RegisterRequest
    {

        [Required]
        public string FirstName { get; set; } = "";

        [Required]
        public string LastName { get; set; } = "";

        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Required, MinLength(8)]
        public string Password { get; set; } = "";

        public string? Phone { get; set; }

        [Required]
        public string Role { get; set; } = "Participant";
    }

    public class LoginRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}
