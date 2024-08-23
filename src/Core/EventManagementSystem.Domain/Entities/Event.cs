using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Domain.Entities
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly Date { get; set; }
        public string Location { get; set; }
        public int SpeakerId { get; set; }
        public ICollection<Registration> Registrations { get; set; } = new List<Registration>();
        public Speaker? Speaker { get; set; }
    }
}
