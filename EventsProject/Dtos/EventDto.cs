using EventsProject.Model;
using System.ComponentModel.DataAnnotations;

namespace EventsProject.Dtos
{
    public class EventDto: BaseDto<EventDto, Event>
    {
        [Required]
        public string Name { get; set; }

        public string? Topic { get; set; }

        public string? Discription { get; set; }

        public string? Plan { get; set; }

        public string? Organizer { get; set; }

        public string? SpeakerName { get; set; }
        public string? SpeakerSurname { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        public string Place { get; set; }


        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(dest => dest.Speaker, src => $"{src.SpeakerName} ({src.SpeakerSurname})");


            SetCustomMappingsInverse()
                .Map(dest => dest.SpeakerName,
                     src => src.Speaker.Split(" ", StringSplitOptions.None)[0])
                .Map(dest => dest.SpeakerSurname,
                     src => src.Speaker.Split(" ", StringSplitOptions.None)[1]);
        }
    }
}
