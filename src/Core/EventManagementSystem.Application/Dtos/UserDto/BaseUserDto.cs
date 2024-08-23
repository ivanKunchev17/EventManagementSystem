using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Dtos.UserDto
{
    public abstract class BaseUserDto
    {
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
        public string Email { get; set; }

     
        public DateOnly DateOfBirth { get; set; }
    }
}
