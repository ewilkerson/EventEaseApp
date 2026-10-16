using EventEaseApp.Models;
using System.Text.Json;

namespace EventEaseApp.Services
{
    public class EventService
    {
        private readonly HttpClient _httpClient;
        private const string JsonFilePath = "sample-events.json";

        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get all events
        public async Task<List<Event>> GetEventsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Event>>(JsonFilePath) ?? new List<Event>();
        }

        // Get an event by ID
        public async Task<Event?> GetEventByIdAsync(int eventId)
        {
            var events = await GetEventsAsync();
            return events.FirstOrDefault(e => e.Id == eventId);
        }

        // Add an attendee to an event
        public async Task AddAttendeeAsync(int eventId, string attendee)
        {
            var events = await GetEventsAsync();
            var selectedEvent = events.FirstOrDefault(e => e.Id == eventId);

            if (selectedEvent != null && !selectedEvent.Attendees.Contains(attendee))
            {
                selectedEvent.Attendees.Add(attendee);
                await SaveEventsAsync(events);
            }
        }

        // Save updated events
        private async Task SaveEventsAsync(List<Event> events)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(events, options);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", JsonFilePath);
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
