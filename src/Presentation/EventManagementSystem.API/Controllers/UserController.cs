using EventManagementSystem.Application.Dtos.UserDto;
using EventManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<ReadUserDto> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public ReadUserDto GetById(int id)
        {
            return _userService.Get(id);
        }
        [HttpGet]
        [Route("{id}/UserWithEvents")]
        public ReadUserDto GetUserWithEvents(int id)
        {
            return _userService.GetUserWithEvents(id);
        }

        [HttpPost]
        public void Post([FromBody] CreateUserDto userFromRequest)
        {
            _userService.Add(userFromRequest);
        }

        [HttpPut]
        public void Put([FromBody] UpdateUserDto userFromRequest)
        {
            _userService.Update(userFromRequest);
        }

        [HttpDelete]
        [Route("{id}/Delete")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }
    }
}
