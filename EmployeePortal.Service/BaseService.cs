using EmployeePortal.Core.Interfaces.Repository;
using EmployeePortal.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePortal.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected IRepositoryBase<T> _repository;

        public BaseService(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }
        public virtual void Create(T entity)
        {
            _repository.Create(entity);
        }

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public virtual IEnumerable<T> FindAll()
        {
            return _repository.FindAll();
        }

        public virtual T FindById(int id)
        {
            return _repository.FindById(id);
        }

        public virtual void Save()
        {
            _repository.Save();
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
