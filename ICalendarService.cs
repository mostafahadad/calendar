using Calender.Data.Entities;

namespace Calender.Services.Calendars
{
    public interface ICalendarService
    {
        Task<Calendar> GetByIdAsync(int id);
        Task<Calendar> AddAsync(Calendar calendar);
        Task<Calendar> UpdateAsync(Calendar calendar);  
    }
}
