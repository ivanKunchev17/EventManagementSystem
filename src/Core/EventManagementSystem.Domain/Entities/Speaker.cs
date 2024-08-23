using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Domain.Entities
{
    public class Speaker
    {
        [Key]
        public int SpeakerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string Email { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
