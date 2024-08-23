using EventManagementSystem.Application.Dtos.RegistrationDto;
using EventManagementSystem.Application.Dtos.SpeakerDto;
using EventManagementSystem.Application.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Dtos.EventDto
{
    public class ReadEventDto : BaseEventDto
    {
        public List<ReadRegistrationDto> Registrations { get; set; } = new List<ReadRegistrationDto>();
        public ReadSpeakerDto? Speaker { get; set; }
    }
}
