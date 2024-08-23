using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Dtos.RegistrationDto
{
    public abstract class BaseRegistrationDto
    {
        public int EventId { get; set; }
        public string UserEmail { get; set; }

    }
}
