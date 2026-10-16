namespace EventEaseApp.Services
{
    public class SessionState
    {
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public Dictionary<int, List<string>> EventAttendees { get; private set; } = new Dictionary<int, List<string>>();

        public void RegisterForEvent(int eventId, string attendee)
        {
            if (!EventAttendees.ContainsKey(eventId))
            {
                EventAttendees[eventId] = new List<string>();
            }

            if (!EventAttendees[eventId].Contains(attendee))
            {
                EventAttendees[eventId].Add(attendee); // Add attendee to the event
            }
        }

        public List<string> GetAttendeesForEvent(int eventId)
        {
            return EventAttendees.ContainsKey(eventId) ? EventAttendees[eventId] : new List<string>();
        }

    }
}
