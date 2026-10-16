using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace raceday_api.Data
{
    public class racedaycontext : DbContext
    {
        public racedaycontext(DbContextOptions<racedaycontext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<EventImage> EventImages { get; set; }
    }

}

