using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using raceday_api.Data;
using raceday_api.Models;

namespace raceday_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly racedaycontext _db;

        public EventsController(racedaycontext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _db.Events
                .AsNoTracking()
                .ToListAsync();

            return Ok(events);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var item = await _db.Events
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.EventID == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(Event item)
        {
            int? userId = HttpContext.Session.GetInt32("UserID");
            string? role = HttpContext.Session.GetString("Role");

            if (userId == null)
                return Unauthorized();

            if (role != "Organiser")
                return Forbid();

            item.OrganiserID = userId.Value;
            item.EventID = 0;

            _db.Events.Add(item);
            await _db.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetEvent),
                new { id = item.EventID },
                item);
        }
    }
}
