using EmployeePortal.Core.Domain;
using EmployeePortal.Core.Interfaces.Repository;
 using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePortal.Data.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeePortalDbContext context) : base(context)
        {

        }
    }
}
