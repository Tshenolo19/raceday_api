using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using raceday_api.Data;
using raceday_api.Models;

namespace raceday_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly racedaycontext _db;
        private readonly PasswordHasher<User> _hasher = new();

        public AuthController(racedaycontext db)
        {
            _db = db;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegisterRequest request)
        {
            string role = request.Role.Trim();

            if (role != "Organiser" &&
                role != "Participant")
            {
                return BadRequest(
                    "Role must be Organiser or Participant.");
            }

            string email = request.Email.Trim().ToLowerInvariant();

            if (await _db.Users.AnyAsync(u => u.Email == email))
            {
                return Conflict("Email is already registered.");
            }

            var user = new User
            {
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                Email = email,
                Phone = request.Phone,
                Role = role
            };

            user.PasswordHash = _hasher.HashPassword(
                user, request.Password);

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return StatusCode(201, new
            {
                user.UserID,
                user.FirstName,
                user.LastName,
                user.Email,
                user.Role
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginRequest request)
        {
            string email = request.Email.Trim().ToLowerInvariant();

            var user = await _db.Users
                .SingleOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return Unauthorized("Invalid email or password.");

            var verification = _hasher.VerifyHashedPassword(
                user, user.PasswordHash, request.Password);

            if (verification == PasswordVerificationResult.Failed)
                return Unauthorized("Invalid email or password.");

            HttpContext.Session.SetInt32("UserID", user.UserID);
            HttpContext.Session.SetString("Role", user.Role);

            return Ok(new
            {
                Message = "Login successful.",
                user.UserID,
                user.FirstName,
                user.Role
            });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Ok(new { Message = "Logged out successfully." });
        }
    }
}
