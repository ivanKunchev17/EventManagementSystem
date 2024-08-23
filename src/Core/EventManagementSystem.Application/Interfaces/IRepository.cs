using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementSystem.Application.IRepository
{
    public interface IRepository <T>
    {
        void Create(T entity);
        T Read(int id,bool loadNavProps);
        List<T> ReadAll(bool loadNavProps);
        void Update(T entity);
        void Delete(int id);

        
    }
}
