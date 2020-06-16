using DataModels.Models;
using System.Collections.Generic;

namespace DataModels.Iterfaces
{
    public interface IDiManager
    {
        IEnumerable<Item> GetItems();
        Item GetItem(string itemCode);
        IEnumerable<BusinessPartner> GetBusinessPartners();
        BusinessPartner GetBusinessPartner(string bpCode);
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int employeeCode);
        IEnumerable<Territory> GetTerritories();
        Territory GetTerritory(int territoryId);
        IEnumerable<Project> GetProjects();
        Project GetProject(string projectCode);
        IEnumerable<WareHouse> GetWareHouses();
        WareHouse GetWareHouse(string wareHouseCode);
        ItemsWarehouses GetItemTotalInfo(string itemCode);
        ItemsWarehouses GetItemInfoInWareHouse(string itemCode, string wareHouseCode);
    }
}
