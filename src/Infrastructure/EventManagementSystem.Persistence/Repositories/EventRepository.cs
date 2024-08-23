using EventManagementSystem.Application.IRepository;
using EventManagementSystem.Domain.Entities;
using EventManagementSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

public class EventRepository : IRepository<Event>
{
    private readonly EventManagementSystemContext _context;
    public EventRepository(EventManagementSystemContext context)
    {
        _context = context;
    }
    public void Create(Event entity)
    {
        _context.Events.Add(entity);
        _context.SaveChanges();
    }

    public Event Read(int id, bool loadNavProps)
    {
        IQueryable<Event> query = _context.Events;

        if (loadNavProps)
        {
            query = query
                 .Include(x => x.Speaker)
                 .Include(x => x.Registrations)
                 .ThenInclude(x => x.User);
        }

        return query.FirstOrDefault(x => x.EventId == id);
    }

    public List<Event> ReadAll(bool loadNavProps)
    {
        IQueryable<Event> events = _context.Events;

        if (loadNavProps)
        {
            events = events
                .Include(r => r.Registrations)
                .ThenInclude(u => u.User)
                .Include(s => s.Speaker);
        }

        return events.ToList();
    }

    public void Update(Event entity)
    {
        Event eventFromRepository = Read(entity.EventId, false);

        if (eventFromRepository != null)
        {
            eventFromRepository.Title = entity.Title;
            eventFromRepository.Description = entity.Description;
            eventFromRepository.Date = entity.Date;
            eventFromRepository.Location = entity.Location;
            _context.SaveChanges();
        }
        else
        {
            throw new Exception("Event doesn`t exist");
        }
    }

    public void Delete(int id)
    {
        Event eventFromRepository = Read(id, false);

        if (eventFromRepository != null)
        {
            _context.Events.Remove(eventFromRepository);
            _context.SaveChanges();
        }
        else
        {
            throw new Exception("Event doesn`t exist");
        }
    }
}
