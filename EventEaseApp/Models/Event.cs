namespace EventEaseApp.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public List<string> Attendees { get; set; } = new List<string>();
        public void AddAttendee(string attendee)
        {
            if (!Attendees.Contains(attendee))
            {
                Attendees.Add(attendee);
            }
        }
    }
}
