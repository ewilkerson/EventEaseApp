using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models
{
    public class Registration
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

     //   [Required(ErrorMessage = "Event ID is required.")]
        public int EventId { get; set; }
    }
}
