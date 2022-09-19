using System.ComponentModel.DataAnnotations;

namespace EventsProject.Model
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Topic { get; set; }

        public string? Discription { get; set; }

        public string? Plan { get; set; }

        public string? Organizer { get; set; }

        public string? Speaker { get; set; } 

        public DateTime DateTime { get; set; }

        [Required]
        public string Place { get; set; }
    }
}
