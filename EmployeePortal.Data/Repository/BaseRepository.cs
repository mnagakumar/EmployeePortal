using EmployeePortal.Core.Domain;
using EmployeePortal.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePortal.Data.Repository
{
    public class BaseRepository<T> : IRepositoryBase<T> where T:class
    {
        protected EmployeePortalDbContext _context { get; set; }
        public BaseRepository(EmployeePortalDbContext context)
        {
            _context = context;
        }

        public virtual void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual IEnumerable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public virtual T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
