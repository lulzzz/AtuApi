using DataModels.Models;
using System.Collections.Generic;

namespace DataModels.Iterfaces
{
    public interface IDiManager
    {
        IEnumerable<Item> GetItems();
        Item GetItem(string itemCode);
        BusinessPartner GetBusinessPartner(string bpCode);
        IEnumerable<BusinessPartner> GetBusinessPartners();
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int employeeCode);
    }
}
