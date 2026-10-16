using System.ComponentModel.DataAnnotations;
namespace raceday_api.Models
{
    public class Event
    {
         
        public int EventID { get; set; }

        [Required]
        public int OrganiserID { get; set; }

        [Required, MaxLength(100)]
        public string EventName { get; set; } = "";

        public string Description { get; set; } = "";

        public DateTime EventDate { get; set; }

        [Required]
        public string Location { get; set; } = "";

        public decimal Distance { get; set; }

        [Required]
        public string EventType { get; set; } = "Run";

        public DateTime CreatedAt { get; set; } =
            DateTime.UtcNow;

        public User? Organiser { get; set; }
        public ICollection<Category> Categories { get; set; }
            = new List<Category>();
    }
}

