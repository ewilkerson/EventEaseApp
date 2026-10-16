using EventEaseApp.Models;

namespace EventEaseApp.Services
{
    public class SessionState
    {
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;

        public List<Attendee> Attendees { get; private set; } = new();
        public event Action OnStateChange;

        public void RegisterAttendee(Registration attendee)
        {
            Attendee newAttendee = new Attendee
            {
                Name = attendee.Name,
                Email = attendee.Email,
                Id = attendee.EventId
            };
            Attendees.Add(newAttendee);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();

        public List<Attendee> GetAttendeesForEvent(int eventId)
        {
            return Attendees.Where(a => a.Id == eventId).ToList();
        }

    }
}
