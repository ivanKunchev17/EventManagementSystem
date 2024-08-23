using EventManagementSystem.Application.IRepository;
using EventManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Persistence.Repositories
{
    public class RegistrationRepository : IRepository<Registration>
    {
        private readonly EventManagementSystemContext _context;
        public RegistrationRepository(EventManagementSystemContext context)
        {
            _context = context;
        }
        public void Create(Registration entity)
        {
            _context.Registrations.Add(entity);
            _context.SaveChanges();
        }

        public Registration Read(int id, bool loadNavProps)
        {
            IQueryable<Registration> registrations = _context.Registrations;

            if(loadNavProps)
            {
                registrations = registrations
                    .Include(u => u.User)
                    .Include(e => e.Event)
                    .ThenInclude(s => s.Speaker);
            }

            return registrations.SingleOrDefault(x => x.UserId == id);
        }

        public List<Registration> ReadAll(bool loadNavProps)
        {
            IQueryable<Registration> registrations = _context.Registrations;

            if (loadNavProps)
            {
                registrations = registrations
                    .Include(u => u.User)
                    .Include(e => e.Event)
                    .ThenInclude(s => s.Speaker);
            }
            return registrations.ToList();
        }

        public void Update(Registration entity)
        {
            Registration registrationFromRepository = Read(entity.RegistrationId, false);

            if (registrationFromRepository != null)
            {
                registrationFromRepository.RegistrationDate = DateOnly.FromDateTime(DateTime.Now);
                registrationFromRepository.EventId = entity.EventId;
                registrationFromRepository.UserId = entity.UserId;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Registration doesn`t exist");
            }
        }

        public void Delete(int id)
        {
            Registration registrationFromRepository = Read(id,false);

            if (registrationFromRepository != null)
            {
                _context.Registrations.Remove(registrationFromRepository);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Registration doesn`t exist");
            }
        }
    }
}
