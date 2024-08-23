using EventManagementSystem.Application.Dtos.RegistrationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Interfaces
{
    public interface IRegistrationService
    {
        void Add(CreateRegistrationDto entity);
        ReadRegistrationDto Get(int id);
        List<ReadRegistrationDto> GetAll();
        void Update(UpdateRegistrationDto entity);
        void Delete(int id);
    }
}
