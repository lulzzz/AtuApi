using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Dtos
{
    public class ApprovalsEmployeesDto
    {
        public ApprovalsEmployeesDto()
        {
            EmployeeCodes = new List<int>();
        }
        public List<int> EmployeeCodes { get; set; }

    }
}
