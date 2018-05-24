using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePortal.Core.Interfaces.Service
{
    public interface IBaseService<T>
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
