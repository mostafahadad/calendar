namespace Calender.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Mail { get; set; }
        public Calendar Calendar { get; set; }
    }
}
