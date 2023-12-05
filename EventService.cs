using Calender.Data;
using Calender.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Calender.Services.Events
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Event>> GetAllAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            var calendarEvent = await _context.Events.FindAsync(id);

            if (calendarEvent == null) throw new KeyNotFoundException($"No event with ID {id} was found");

            return calendarEvent;
        }

        public async Task<Event> AddAsync(Event calendarEvent)
        {
            if(calendarEvent == null) throw new ArgumentNullException(nameof(calendarEvent), "Provided event is null");

            await _context.AddAsync(calendarEvent);
            await _context.SaveChangesAsync();

            return calendarEvent;
        }

        public async Task<Event> UpdateAsync(Event calendarEvent)
        {
            if (calendarEvent == null) throw new ArgumentNullException(nameof(calendarEvent), "Provided event is null");

            var existingEvent = await _context.Events.FindAsync(calendarEvent.Id);
            if(existingEvent == null) throw new KeyNotFoundException($"No event with ID {calendarEvent.Id} was found");

            _context.Entry(calendarEvent).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return calendarEvent;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var calendarEvent = await _context.Events.FindAsync(id);

            if (calendarEvent == null) throw new KeyNotFoundException($"No event with ID {id} was found");

            _context.Remove(calendarEvent);
            await _context.SaveChangesAsync();
        }
    }
}
