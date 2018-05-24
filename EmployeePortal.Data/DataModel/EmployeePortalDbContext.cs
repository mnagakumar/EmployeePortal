using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePortal.Core.Domain
{
    public class EmployeePortalDbContext : DbContext
    {
        public EmployeePortalDbContext(DbContextOptions options) 
            : base(options)
        {
               
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
