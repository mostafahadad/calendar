using Calender.Data;
using Calender.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calender.Services.Calendars
{
    public class CalendarService : ICalendarService
    {
        private readonly ApplicationDbContext _context;
        public CalendarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Calendar> GetByIdAsync(int id)
        {
            var calendar = await _context.Calendars.FindAsync(id);

            if (calendar == null) throw new KeyNotFoundException($"No calendar with ID {id} was found");

            return calendar;
        }

        public async Task<Calendar> AddAsync(Calendar calendar)
        {
            if (calendar == null)
            {
                throw new ArgumentNullException(nameof(calendar), "Provided calendar is null.");
            }

            await _context.Calendars.AddAsync(calendar);
            await _context.SaveChangesAsync();

            return calendar;
        }

        public async Task<Calendar> UpdateAsync(Calendar calendar)
        {
            if (calendar == null)
            {
                throw new ArgumentNullException(nameof(calendar), "Provided calendar is null.");
            }

            var existingCalendar = await _context.Calendars.FindAsync(calendar.Id);
            if (existingCalendar == null)
            {
                throw new KeyNotFoundException($"No calendar with ID {calendar.Id} was found");
            }

            _context.Entry(calendar).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return calendar;
        }
    }
}
