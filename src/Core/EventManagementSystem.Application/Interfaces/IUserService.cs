using EventManagementSystem.Application.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Interfaces
{
    public interface IUserService
    {
        void Add(CreateUserDto entity);
        ReadUserDto Get(int id);
        public ReadUserDto GetUserWithEvents(int id);
        List<ReadUserDto> GetAll();
        void Update(UpdateUserDto entity);
        void Delete(int id);
    }
}
