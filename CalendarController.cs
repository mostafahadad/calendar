using Calender.Data.Entities;
using Calender.Services.Calendars;
using Microsoft.AspNetCore.Mvc;

namespace Calender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _calendarService;

        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Calendar>> GetCalendar(int id)
        {
            try
            {
                return Ok(await _calendarService.GetByIdAsync(id));
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Calendar>> PostCalendar(Calendar calendar)
        {
            var newCalendar = await _calendarService.AddAsync(calendar);

            return CreatedAtAction("GetCalendar", new { id = newCalendar.Id }, newCalendar);
        }
    }
}
