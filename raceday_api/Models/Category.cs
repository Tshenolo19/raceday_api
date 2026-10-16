using System.ComponentModel.DataAnnotations;
namespace raceday_api.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public int EventID { get; set; }

        [Required]
        public string CategoryName { get; set; } = "";

        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public decimal Distance { get; set; }

        public Event? Event { get; set; }
    }
}
