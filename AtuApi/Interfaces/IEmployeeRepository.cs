using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee GetEmployee(int employeeCode);
        IEnumerable<Employee> GetEmployees();
    }
}
