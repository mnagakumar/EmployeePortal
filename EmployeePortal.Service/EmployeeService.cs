using EmployeePortal.Core.Domain;
using EmployeePortal.Core.Interfaces.Repository;
using EmployeePortal.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePortal.Service
{
    public class EmployeeService : BaseService<Employee>,IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository repository):
            base(repository)
        {
            _employeeRepository = repository;
        }
    }
}
