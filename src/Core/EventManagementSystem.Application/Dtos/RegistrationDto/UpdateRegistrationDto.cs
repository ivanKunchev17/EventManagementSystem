using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Dtos.RegistrationDto
{
    public class UpdateRegistrationDto : BaseRegistrationDto
    {
        public int RegistrationId { get; set; }
    }
}
