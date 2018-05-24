using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePortal.Core.Domain
{
    public class BaseEntity
    {
        public string Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Updated_By { get; set; }
        public DateTime Updated_Date { get; set; }
    }
}
