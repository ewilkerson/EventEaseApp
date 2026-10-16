using EventEaseApp.Models;

namespace EventEaseApp.Services
{
    public class SessionState
    {
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;

        public List<Registration> Attendees { get; private set; } = new();
        public event Action OnStateChange;

        public void RegisterAttendee(Registration attendee)
        {
            Attendees.Add(attendee);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();

        public List<Registration> GetAttendeesForEvent(int eventId)
        {
            return Attendees.Where(a => a.EventId == eventId).ToList();
        }

    }
}
