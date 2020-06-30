using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtuApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _unitOfWork.EmployeeRepository.GetEmployees();
            Request.HttpContext.Response.Headers.Add("Total-Count", employees.Count().ToString());
            return base.Ok(employees);
        }
        [HttpGet("{employeeCode}")]
        public IActionResult GetEmployee(int employeeCode)
        {
            var employee = _unitOfWork.EmployeeRepository.GetEmployee(employeeCode);
            return employee == null ? NotFound() : (IActionResult)Ok(employee);
        }
    }
}