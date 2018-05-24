using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.ViewModels
{
    public class EmployeeViewModel
    {
        public double Employee_Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Gender { get; set; }

        public DateTime Date_Of_Birth { get; set; }

        public string Father_Name { get; set; }

        public DateTime Date_Of_Join { get; set; }

        public string Qualification { get; set; }
         
        public string Nationality { get; set; }

        public string Email { get; set; }
    }
}
