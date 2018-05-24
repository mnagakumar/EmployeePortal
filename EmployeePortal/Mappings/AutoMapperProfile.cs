using AutoMapper;
using EmployeePortal.Core.Domain;
using EmployeePortal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<EmployeeViewModel, Employee>();
        }
    }
}
