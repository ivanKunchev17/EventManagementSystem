using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EventManagementSystem.Application;
using EventManagementSystem.Application.Dtos.UserDto;
using EventManagementSystem.Application.Interfaces;
using EventManagementSystem.Application.IRepository;
using EventManagementSystem.Application.Validators.UserValidator;
using EventManagementSystem.Domain.Entities;
using FluentValidation;


namespace EventManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly CreateUserDtoValidator _validator;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = new CreateUserDtoValidator();
        }

        public void Add(CreateUserDto entity)
        {
            _validator.Validate(entity);
            User userFromClient = _mapper.Map<User>(entity);
            _repository.Create(userFromClient);
        }

        public ReadUserDto Get(int id)
        {
            User userFromDb = _repository.Read(id,false);
            return _mapper.Map<ReadUserDto>(userFromDb);
        }

        public ReadUserDto GetUserWithEvents(int id)
        {
            User userFromDb = _repository.Read(id,true);
            return _mapper.Map<ReadUserDto>(userFromDb);
        }

        public List<ReadUserDto> GetAll()
        {
            List<User> usersFromDb = _repository.ReadAll(false);
            return _mapper.Map<List<ReadUserDto>>(usersFromDb);
        }

        public void Update(UpdateUserDto entity)
        {
            User userFromClient = _mapper.Map<User>(entity);
            _repository.Update(userFromClient);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
