using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePortal.Core.Interfaces.Repository
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
        T FindById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
