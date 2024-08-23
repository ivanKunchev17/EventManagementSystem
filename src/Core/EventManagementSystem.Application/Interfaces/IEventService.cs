using EventManagementSystem.Application.Dtos.EventDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Interfaces
{
    public interface IEventService
    {
        void Add(CreateEventDto entity);
        ReadEventDto Get(int id);
        List<ReadEventDto> GetAll();
        public ReadEventDto GetWithUsers(int id);
        List<ReadEventDto> GetUpcomingEvents();
        void Update(UpdateEventDto entity);
        void Delete(int id);
    }
}
