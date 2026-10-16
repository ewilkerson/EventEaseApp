using EventEaseApp.Models;
using System.Text.Json;

namespace EventEaseApp.Services
{
    public class SessionState
    {
        private string JsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "sample-attendees.json");

        public async Task<List<Registration>> GetRegistrationsForEventAsync(int eventId)
        {
            // var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", JsonFilePath);
           // var filePath = JsonFilePath;
            if (!File.Exists(JsonFilePath))
            {
                return new List<Registration>();
            }

            string jsonString = await File.ReadAllTextAsync(JsonFilePath);
            return JsonSerializer.Deserialize<List<Registration>>(jsonString) ?? new List<Registration>();
        }

        // Add an attendee to an event
        public async Task AddAttendeeAsync(int eventId, Registration attendee)
        {
            List<Registration> registrations = await GetRegistrationsForEventAsync(eventId);
           
            if (registrations != null && attendee != null)
            {
                attendee.Id = registrations.Count == 0 ? 1 : registrations.Max(x => x.Id) + 1;
                registrations.Add(attendee);
                await SaveEventsAsync(registrations);
            }
        }

        // Save updated events
        private async Task SaveEventsAsync(List<Registration> registrations)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(registrations, options);
            //  var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", JsonFilePath);
           // var filePath = JsonFilePath;
            await File.WriteAllTextAsync(JsonFilePath, json);
        }

    }
}
