using AutoMapper;
using EventManagementSystem.Application.Dtos.RegistrationDto;
using EventManagementSystem.Application.Interfaces;
using EventManagementSystem.Application.IRepository;
using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Registration> _registrationRepository;
        private readonly IMapper _mapper;

        public RegistrationService(IUserRepository userRepository, IRepository<Registration> registrationRepository, IMapper mapper)
        {
            _registrationRepository = registrationRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void Add(CreateRegistrationDto entity)
        {
            Registration newRegistration = _mapper.Map<Registration>(entity);
            newRegistration.UserId = _userRepository.GetUserIdByEmail(entity.UserEmail);
            _registrationRepository.Create(newRegistration);
        }

        public ReadRegistrationDto Get(int id)
        {
            Registration registration = _registrationRepository.Read(id,true);
            ReadRegistrationDto registrationDto = _mapper.Map<ReadRegistrationDto>(registration);
            return registrationDto;
        }

        public List<ReadRegistrationDto> GetAll()
        {
            List<Registration> registrations = _registrationRepository.ReadAll(true);
            return _mapper.Map<List<ReadRegistrationDto>>(registrations);
        }

        public void Update(UpdateRegistrationDto entity)
        {
            Registration registration = _mapper.Map<Registration>(entity);
            registration.UserId = _userRepository.GetUserIdByEmail(entity.UserEmail);
            _registrationRepository.Update(registration);
        }

        public void Delete(int id)
        {
            _registrationRepository.Delete(id);
        }
    }
}
