using EventManagementSystem.Application.Dtos.SpeakerDto;
using EventManagementSystem.Application.Dtos.UserDto;
using EventManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private readonly ISpeakerService _speakerService;

        public SpeakerController(ISpeakerService speaakerService)
        {
            _speakerService = speaakerService;
        }

        [HttpGet]
        public List<ReadSpeakerDto> GetAll()
        {
            return _speakerService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public ReadSpeakerDto GetById(int id)
        {
            return _speakerService.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] CreateSpeakerDto userFromRequest)
        {
            _speakerService.Add(userFromRequest);
        }

        [HttpPut]
        public void Put([FromBody] UpdateSpeakerDto userFromRequest)
        {
            _speakerService.Update(userFromRequest);
        }

        [HttpDelete]
        [Route("{id}/Delete")]
        public void Delete(int id)
        {
            _speakerService.Delete(id);
        }
    }
}
