using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Dtos.EventDto
{
    public class UpdateEventDto : BaseEventDto
    {
        public int EventId { get; set; }
    }
}
