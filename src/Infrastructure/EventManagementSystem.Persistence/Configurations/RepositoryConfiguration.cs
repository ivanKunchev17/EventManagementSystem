using EventManagementSystem.Application.Interfaces;
using EventManagementSystem.Application.IRepository;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Persistence.RegisterRepositories
{
    public static class RepositoryConfiguration
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository<Speaker>, SpeakerRepository>();
            services.AddScoped<IRepository<Event>, EventRepository>();
            services.AddScoped<IRepository<Registration>, RegistrationRepository>();
        }
    }
}
