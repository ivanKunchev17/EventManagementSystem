using EventManagementSystem.Application.Dtos.EventDto;
using EventManagementSystem.Application.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Dtos.RegistrationDto
{
    public class ReadRegistrationDto : BaseRegistrationDto
    {
        public DateOnly RegistrationDate { get; set; }
        public ReadUserDto? User { get; set; }
        public ReadEventDto? Event { get; set; }
    }
}
