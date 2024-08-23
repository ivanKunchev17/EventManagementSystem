using AutoMapper;
using EventManagementSystem.Application.Dtos.EventDto;
using EventManagementSystem.Application.Interfaces;
using EventManagementSystem.Application.IRepository;
using EventManagementSystem.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _repository;
        private readonly IValidator<BaseEventDto> _validator;
        private readonly IValidator<UpdateEventDto> _updateValidator;
        private readonly IMapper _mapper;
        public EventService(IRepository<Event> repository, IMapper mapper, IValidator<BaseEventDto> validator, IValidator<UpdateEventDto> updateValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
            _updateValidator = updateValidator;
        }

        public void Add(CreateEventDto entity)
        {
            _validator.Validate(entity);
            Event eventFromClient = _mapper.Map<Event>(entity);
            _repository.Create(eventFromClient);
        }

        public ReadEventDto Get(int id)
        {
            Event eventFromDb = _repository.Read(id, false);
            return _mapper.Map<ReadEventDto>(eventFromDb);
        }

        public List<ReadEventDto> GetAll()
        {
            List<Event> eventsFromDb = _repository.ReadAll(false);
            return _mapper.Map<List<ReadEventDto>>(eventsFromDb);
        }

        public List<ReadEventDto> GetUpcomingEvents()
        {
            List<Event> events = _repository.ReadAll(true);
            List<Event> upcomingEvents = new List<Event>();

            foreach (Event eventItem in events)
            {
                if (eventItem.Date > DateOnly.FromDateTime(DateTime.UtcNow))
                {
                    upcomingEvents.Add(eventItem);
                }
            }

            return _mapper.Map<List<ReadEventDto>>(upcomingEvents);
        }

        public ReadEventDto GetWithUsers(int id)
        {
            Event eventFromDb = _repository.Read(id, true);
            return _mapper.Map<ReadEventDto>(eventFromDb);
        }

        public void Update(UpdateEventDto entity)
        {
            _updateValidator.Validate(entity);
            Event eventFromClient = _mapper.Map<Event>(entity);
            _repository.Update(eventFromClient);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
