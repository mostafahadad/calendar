namespace Calender.Data.Entities
{
    public class Calendar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
        public Guid UserId { get; set; } 
        public User User { get; set; }
    }
}
