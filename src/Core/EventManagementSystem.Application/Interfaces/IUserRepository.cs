using EventManagementSystem.Application.IRepository;
using EventManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        int GetUserIdByEmail(string email);
    }
}
