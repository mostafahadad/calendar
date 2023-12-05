using Calender.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calender.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
