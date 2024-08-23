using EventManagementSystem.Application.Interfaces;
using EventManagementSystem.Application.IRepository;
using EventManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EventManagementSystemContext _context;
        public UserRepository(EventManagementSystemContext context)
        {
            _context = context;
        }

        public void Create(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public User Read(int id,bool loadNavProps)
        {
            IQueryable<User> users = _context.Users;

            if (loadNavProps)
            {
                users = users
                    .Include(r => r.Registrations)
                    .ThenInclude(x => x.Event)
                    .ThenInclude(s=>s.Speaker);
            }
            
            return users.SingleOrDefault(x => x.UserId == id);
        }

        public List<User> ReadAll(bool loadNavProps)
        {
            IQueryable<User> users = _context.Users;

            if (loadNavProps)
            {
                users = users
                    .Include(r => r.Registrations)
                    .ThenInclude(x => x.Event)
                    .ThenInclude(s => s.Speaker);
            }

            return users.ToList();
        }

        public void Update(User entity)
        {
            User userFromRepository = Read(entity.UserId,false);

            if (userFromRepository != null)
            {
                userFromRepository.FirstName = entity.FirstName;
                userFromRepository.LastName = entity.LastName;
                userFromRepository.Email = entity.Email;
                userFromRepository.DateOfBirth = entity.DateOfBirth;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("User doesn`t exist");
            }
        }

        public void Delete(int id)
        {
            User userFromRepository = Read(id, false);

            if (userFromRepository != null)
            {
                _context.Users.Remove(userFromRepository);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("User doesn`t exist");
            }
        }

        public int GetUserIdByEmail(string email)
        {
            User userFromDb = _context.Users.SingleOrDefault(x => x.Email == email);

            if(userFromDb ==  null)
            {
                throw new Exception($"this email: {email} doesn`t exist");
            }

            return userFromDb.UserId;
        }
    }
}
