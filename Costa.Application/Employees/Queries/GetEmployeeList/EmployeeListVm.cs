using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costa.Application.Employees.Queries.GetEmployeeList
{
    public class EmployeeListVm
    {
        public IList<EmployeeLookupDto> Employees { get; set; }
    }
}
