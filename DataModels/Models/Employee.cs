using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public int EmpId { get; set; }
        public string Position { get; set; }
        public int PositionCode { get; set; }
        public string Department { get; set; }
        public int DepartmentCode { get; set; }
    }
}
