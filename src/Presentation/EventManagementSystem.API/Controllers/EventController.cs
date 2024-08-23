using EventManagementSystem.Application.Dtos.EventDto;
using EventManagementSystem.Application.Dtos.UserDto;
using EventManagementSystem.Application.Interfaces;
using EventManagementSystem.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public List<ReadEventDto> GetAll()
        {
            return _eventService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public ReadEventDto GetById(int id)
        {
            return _eventService.Get(id);
        }

        [HttpGet]
        [Route("{id}/EventWithUsers")]
        public ReadEventDto GetEventWithUsers(int id)
        {
            return _eventService.GetWithUsers(id);
        }

        [HttpGet]
        [Route("UpcomingEvents")]
        public List<ReadEventDto> GetUpcomingEvents()
        {
            return _eventService.GetUpcomingEvents();
        }
        [HttpPost]
        public void Post([FromBody] CreateEventDto userFromRequest)
        {
            _eventService.Add(userFromRequest);
        }

        [HttpPut]
        public void Put([FromBody] UpdateEventDto userFromRequest)
        {
            _eventService.Update(userFromRequest);
        }

        [HttpDelete]
        [Route("{id}/Delete")]
        public void Delete(int id)
        {
            _eventService.Delete(id);
        }
    }
}
