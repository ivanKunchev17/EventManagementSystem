using EventManagementSystem.Application.Interfaces;
using EventManagementSystem.Application.IRepository;
using EventManagementSystem.Application.Services;
using EventManagementSystem.Domain.Entities;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Extensions
{
    public static class ServiceConfiguration
    {
        public static void RegisterServices(this IServiceCollection service)
        {

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IEventService, EventService>();
            service.AddScoped<IRegistrationService, RegistrationService>();
            service.AddScoped<ISpeakerService, SpeakerService>();
            


            var assembly = Assembly.GetExecutingAssembly();
            service.AddAutoMapper(assembly);
        }
    }
}
