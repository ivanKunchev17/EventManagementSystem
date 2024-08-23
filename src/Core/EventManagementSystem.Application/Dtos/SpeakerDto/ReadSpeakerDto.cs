using EventManagementSystem.Application.Dtos.EventDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Dtos.SpeakerDto
{
    public class ReadSpeakerDto  : BaseSpeakerDto
    {
        public List<ReadEventDto> Events = new List<ReadEventDto>();
    }
}
