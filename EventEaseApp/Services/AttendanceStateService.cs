using EventEaseApp.Models;

namespace EventEaseApp.Services
{
    public class AttendanceStateService
    {
        public List<Registration> Attendees { get; private set; } = new();
        public event Action OnStateChange;

        public void RegisterAttendee(Registration attendee)
        {
            Attendees.Add(attendee);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();

    }
}
