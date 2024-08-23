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
    public class SpeakerRepository : IRepository<Speaker>
    {
        private readonly EventManagementSystemContext _context;
        public SpeakerRepository(EventManagementSystemContext context)
        {
            _context = context;
        }
        public void Create(Speaker entity)
        {
            _context.Speakers.Add(entity);
            _context.SaveChanges();
        }

        public Speaker Read(int id, bool loadNavProps)
        {
            IQueryable<Speaker> speakers = _context.Speakers;

            if (loadNavProps)
            {
                speakers = speakers
                    .Include(e => e.Events)
                    .ThenInclude(r => r.Registrations)
                    .ThenInclude(u => u.User);
            }

            return speakers.SingleOrDefault(x => x.SpeakerId == id);
        }

        public List<Speaker> ReadAll(bool loadNavProps)
        {
            IQueryable<Speaker> speakers = _context.Speakers;

            if (loadNavProps)
            {
                speakers = speakers
                    .Include(e => e.Events)
                    .ThenInclude(r => r.Registrations)
                    .ThenInclude(u => u.User);
            }

            return speakers.ToList();
        }

        public void Update(Speaker entity)
        {
            Speaker speakerFromRepository = Read(entity.SpeakerId, false);

            if (speakerFromRepository != null)
            {
                speakerFromRepository.Name = entity.Name;
                speakerFromRepository.Description = entity.Description;
                speakerFromRepository.Email = entity.Email;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Speaker doesn`t exist");
            }
        }

        public void Delete(int id)
        {
            Speaker speakerFromRepository = Read(id, false);

            if (speakerFromRepository != null)
            {
                _context.Speakers.Remove(speakerFromRepository);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Speaker doesn`t exist");
            }
        }
    }
}
