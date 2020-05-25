using AtuApi.Interfaces;
using DataContextHelper;
using DataModels.Iterfaces;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        IDiManager _diManager;

        public EmployeeRepository(DataContext context, IDiManager diManager) : base(context)
        {
            _diManager = diManager;
        }
        public Employee GetEmployee(int employeeCode)
        {
            return _diManager.GetEmployee(employeeCode);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _diManager.GetEmployees();
        }
        private DataContext EmployeeContext => Context as DataContext;

    }
}
