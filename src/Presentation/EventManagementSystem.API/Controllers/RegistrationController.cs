using EventManagementSystem.Application.Dtos.RegistrationDto;
using EventManagementSystem.Application.Dtos.UserDto;
using EventManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace EventManagementSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpGet]
        public List<ReadRegistrationDto> GetAll()
        {
            return _registrationService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public ReadRegistrationDto GetById(int id)
        {
            return _registrationService.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] CreateRegistrationDto userFromRequest)
        {
            _registrationService.Add(userFromRequest);
        }

        [HttpPut]
        public void Put([FromBody] UpdateRegistrationDto userFromRequest)
        {
            _registrationService.Update(userFromRequest);
        }

        [HttpDelete]
        [Route("{id}/Delete")]
        public void Delete(int id)
        {
            _registrationService.Delete(id);
        }
    }
}
