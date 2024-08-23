using EventManagementSystem.Application.Dtos.EventDto;
using EventManagementSystem.Application.Dtos.RegistrationDto;
using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Dtos.UserDto
{
    public class ReadUserDto : BaseUserDto
    {
        public List<ReadRegistrationDto> Registrations = new List<ReadRegistrationDto>();
    }
}
