using AutoMapper;
using EventManagementSystem.Application.Dtos.EventDto;
using EventManagementSystem.Application.Dtos.RegistrationDto;
using EventManagementSystem.Application.Dtos.SpeakerDto;
using EventManagementSystem.Application.Dtos.UserDto;
using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Profiles
{
    public class EventManagementSystemProfile : Profile
    {
        public EventManagementSystemProfile()
        {
            CreateMap<CreateEventDto, Event>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.SpeakerId, opt => opt.MapFrom(src => src.SpeakerId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));

            CreateMap<Event, ReadEventDto>()
                .ForMember(dest => dest.Speaker, opt => opt.MapFrom(src => src.Speaker))
                .ForMember(dest => dest.Registrations, opt => opt.MapFrom(src => src.Registrations))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.SpeakerId, opt => opt.MapFrom(src => src.SpeakerId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));

            CreateMap<UpdateEventDto, Event>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.SpeakerId, opt => opt.MapFrom(src => src.SpeakerId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));


            CreateMap<CreateRegistrationDto, Registration>()
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId));

            CreateMap<Registration, ReadRegistrationDto>()
                 .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
                 .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => src.RegistrationDate))
                 .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                 .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                 .ForMember(dest => dest.Event, opt => opt.MapFrom(src => src.Event));

            CreateMap<UpdateRegistrationDto, Registration>()
                .ForMember(dest => dest.RegistrationId, opt => opt.MapFrom(src => src.RegistrationId))
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId));


            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));

            CreateMap<User, ReadUserDto>()
                .ForMember(dest => dest.Registrations, opt => opt.MapFrom(src => src.Registrations))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));

            CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth));

            CreateMap<CreateSpeakerDto, Speaker>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Speaker, ReadSpeakerDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Events, opt => opt.MapFrom(src => src.Events));

            CreateMap<UpdateSpeakerDto, Speaker>()
                .ForMember(dest => dest.SpeakerId, opt => opt.MapFrom(src => src.SpeakerId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
