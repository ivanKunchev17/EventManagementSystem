using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Dtos.EventDto
{
    public abstract class BaseEventDto 
    {
        public string Title { get; set; }

        public string? Description { get; set; }

        public DateOnly Date { get; set; }

        public int SpeakerId { get; set; }
        public string Location { get; set; }
    }
}
