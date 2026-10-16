namespace EventEaseApp.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<Attendee> Attendees { get; set; } = new List<Attendee>();
        public void AddAttendee(Attendee attendee)
        {
            if (!Attendees.Contains(attendee))
            {
                Attendees.Add(attendee);
            }
        }
    }
}
