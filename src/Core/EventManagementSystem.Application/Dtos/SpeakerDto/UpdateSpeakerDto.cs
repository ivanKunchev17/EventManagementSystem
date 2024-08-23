using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Dtos.SpeakerDto
{
    public class UpdateSpeakerDto : BaseSpeakerDto
    {
        public int SpeakerId { get; set; }
    }
}
