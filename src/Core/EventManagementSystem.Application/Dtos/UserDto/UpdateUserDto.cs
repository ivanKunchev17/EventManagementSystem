using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Dtos.UserDto
{
    public class UpdateUserDto : BaseUserDto
    {
        public int UserId { get; set; }
    }
}
