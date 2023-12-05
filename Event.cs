namespace Calender.Data.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EventCategory Category { get; set; }
        public Calendar Calendar { get; set; }
        public int CalendarId { get; set; }
    }
}
