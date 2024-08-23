using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Domain.Entities
{
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateOnly RegistrationDate { get; set; }
        public User? User { get; set; }
        public Event? Event { get; set; }
    }
}
