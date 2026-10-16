
using System.ComponentModel.DataAnnotations;
namespace raceday_api.Models
{
    public class EventImage
    {
        public int EventImageID { get; set; }
        public int EventID { get; set; }

        [Required]
        public string ImageUrl { get; set; } = "";

        public string ImageType { get; set; } = "Banner";

        public DateTime UploadedAt { get; set; } =
            DateTime.UtcNow;

        public Event? Event { get; set; }
    }
}
