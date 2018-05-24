using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeePortal.Core.Domain;
using EmployeePortal.Core.Interfaces.Service;
using EmployeePortal.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService service)
        {
            _employeeService = service;
        }
        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            var empList =  _employeeService.FindAll();
            var empVM = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(empList);
            return Ok(empVM);
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody]EmployeeViewModel empVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var empEntity = Mapper.Map<EmployeeViewModel, Employee>(empVM);
            _employeeService.Create(empEntity);
            return Ok();
        }
        
        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
