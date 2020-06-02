﻿using DataModels.Iterfaces;
using DataModels.Models;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using Items = SAPbobsCOM.Items;

namespace SapDataAccess
{
    public class DiManager : IDiManager
    {
        private SAPbobsCOM.Company _company { get; set; }
        public DiManager(string server, int dbServerType, string userName, string password, string companyDb)
        {
            _company = new SAPbobsCOM.CompanyClass
            {
                Server = server,
                DbServerType = (BoDataServerTypes)dbServerType,
                UserName = userName,
                Password = password,
                CompanyDB = companyDb,
                language = BoSuppLangs.ln_English
            };
            _company.Connect();
            if (!_company.Connected)
            {
                throw new Exception($"Cannot Connect To the Server : {_company.GetLastErrorDescription()} : " +
                                    $"Server : {_company.Server}, " +
                                    $"DbServerType : {_company.DbServerType}," +
                                    $"UserName : {_company.UserName}," +
                                    $"CompanyDB : {_company.CompanyDB}");
            }
        }
        /// <summary>
        /// Returns Collection Of Items
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataModels.Item> GetItems()
        {
            List<DataModels.Item> items = new List<DataModels.Item>();
            Recordset itemsRecordSet = (Recordset)_company.GetBusinessObject(BoObjectTypes.BoRecordset);
            itemsRecordSet.DoQuery($"SELECT ItemCode, ItemName, BuyUnitMsr From OITM");
            while (!itemsRecordSet.EoF)
            {
                DataModels.Item item = new DataModels.Item
                {
                    ItemCode = itemsRecordSet.Fields.Item("ItemCode").Value.ToString(),
                    ItemName = itemsRecordSet.Fields.Item("ItemName").Value.ToString(),
                    UnitOfMeasurePurchaseCode = itemsRecordSet.Fields.Item("BuyUnitMsr").Value.ToString(),
                };
                items.Add(item);
                itemsRecordSet.MoveNext();
            }
            return items;
        }
        /// <summary>
        /// Returns Item (Null if Not Exists)
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public DataModels.Item GetItem(string itemCode)
        {
            Items items = (Items)_company.GetBusinessObject(BoObjectTypes.oItems);
            bool exists = items.GetByKey(itemCode);
            DataModels.Item item = new DataModels.Item
            {
                ItemCode = items.ItemCode,
                ItemName = items.ItemName,
                UnitOfMeasurePurchaseCode = items.PurchaseUnit,
            };
            return !exists ? null : item;
        }
        /// <summary>
        /// Returns BusinessPartner (Null if Not Exists)
        /// </summary>
        /// <param name="bpCode"></param>
        /// <returns></returns>
        public BusinessPartner GetBusinessPartner(string bpCode)
        {
            BusinessPartners businessPartners = (BusinessPartners)_company.GetBusinessObject(BoObjectTypes.oBusinessPartners);
            bool exists = businessPartners.GetByKey(bpCode);
            BusinessPartner businessPartner = new BusinessPartner
            {
                CardCode = businessPartners.CardCode,
                CardName = businessPartners.CardName,
                FederalTaxId = businessPartners.FederalTaxID,
                GroupCode = businessPartners.GroupCode
            };
            return !exists ? null : businessPartner;
        }
        /// <summary>
        /// Returns Collection Of Business Partners
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BusinessPartner> GetBusinessPartners()
        {
            List<BusinessPartner> BusinessPartners = new List<BusinessPartner>();
            Recordset itemsRecordSet = (Recordset)_company.GetBusinessObject(BoObjectTypes.BoRecordset);
            itemsRecordSet.DoQuery($"SELECT CardCode, CardName, LicTradNum,GroupCode From OCRD");
            while (!itemsRecordSet.EoF)
            {
                BusinessPartner BusinessPartner = new BusinessPartner
                {
                    CardCode = itemsRecordSet.Fields.Item("CardCode").Value.ToString(),
                    CardName = itemsRecordSet.Fields.Item("CardName").Value.ToString(),
                    FederalTaxId = itemsRecordSet.Fields.Item("LicTradNum").Value.ToString(),
                    GroupCode = (int)itemsRecordSet.Fields.Item("GroupCode").Value
                };
                BusinessPartners.Add(BusinessPartner);
                itemsRecordSet.MoveNext();
            }
            return BusinessPartners;
        }
        /// <summary>
        /// Returns Collection Of Employees 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> Employees = new List<Employee>();
            Recordset EmployeesRecordSet = (Recordset)_company.GetBusinessObject(BoObjectTypes.BoRecordset);
            EmployeesRecordSet.DoQuery($@"SELECT FirstName, 
                                               LastName,
                                               position,
                                               OHPS.name as [Position Name],
                                               dept,
                                               OUDP.Name as [Department Name],
                                               govID,
                                               EmpId
                                        FROM OHEM
                                             LEFT JOIN OUDP ON OUDP.Code = OHEM.dept
                                             LEFT JOIN OHPS ON OHPS.posID = position");
            while (!EmployeesRecordSet.EoF)
            {
                Employee Employee = new Employee
                {
                    FirstName = EmployeesRecordSet.Fields.Item("FirstName").Value.ToString(),
                    LastName = EmployeesRecordSet.Fields.Item("LastName").Value.ToString(),
                    Department = EmployeesRecordSet.Fields.Item("Department Name").Value.ToString(),
                    GovId = EmployeesRecordSet.Fields.Item("govID").Value.ToString(),
                    Position = EmployeesRecordSet.Fields.Item("Position Name").Value.ToString(),
                    PositionCode = (int)EmployeesRecordSet.Fields.Item("Position").Value,
                    DepartmentCode = (int)EmployeesRecordSet.Fields.Item("dept").Value,
                    EmpId = (int)EmployeesRecordSet.Fields.Item("EmpId").Value,
                };
                Employees.Add(Employee);
                EmployeesRecordSet.MoveNext();
            }
            return Employees;
        }
        /// <summary>
        /// Returns Employee (Null if Not Exists)
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>       
        public Employee GetEmployee(int employeeCode)
        {
            Recordset EmployeesRecordSet = (Recordset)_company.GetBusinessObject(BoObjectTypes.BoRecordset);
            EmployeesRecordSet.DoQuery($@"SELECT FirstName, 
                                               LastName,
                                               position,
                                               OHPS.name as [Position Name],
                                               dept,
                                               OUDP.Name as [Department Name],
                                               govID,
                                               EmpId
                                        FROM OHEM
                                             LEFT JOIN OUDP ON OUDP.Code = OHEM.dept
                                             LEFT JOIN OHPS ON OHPS.posID = position
                                        WHERE EmpId = {employeeCode}");
            if (!EmployeesRecordSet.EoF)
            {
                Employee Employee = new Employee
                {
                    FirstName = EmployeesRecordSet.Fields.Item("FirstName").Value.ToString(),
                    LastName = EmployeesRecordSet.Fields.Item("LastName").Value.ToString(),
                    Department = EmployeesRecordSet.Fields.Item("Department Name").Value.ToString(),
                    GovId = EmployeesRecordSet.Fields.Item("govID").Value.ToString(),
                    Position = EmployeesRecordSet.Fields.Item("Position Name").Value.ToString(),
                    PositionCode = (int)EmployeesRecordSet.Fields.Item("Position").Value,
                    DepartmentCode = (int)EmployeesRecordSet.Fields.Item("dept").Value,
                    EmpId = (int)EmployeesRecordSet.Fields.Item("EmpId").Value,
                };
                return Employee;
            }
            return null;
        }
        /// <summary>
        /// Returns Territory (Null if Not Exists)
        /// </summary>
        /// <param name="teritoryId"></param>
        /// <returns></returns>
        public Territory GetTerritory(int teritoryId)
        {
            Recordset TerritoryRecordSet = (Recordset)_company.GetBusinessObject(BoObjectTypes.BoRecordset);
            TerritoryRecordSet.DoQuery($@"SELECT *
                                        FROM OTER                                              
                                        WHERE territryID = {teritoryId}");
            if (!TerritoryRecordSet.EoF)
            {
                Territory Territory = new Territory
                {
                    Description = TerritoryRecordSet.Fields.Item("descript").Value.ToString(),
                    TerritoryId = (int)TerritoryRecordSet.Fields.Item("territryID").Value,
                    Lindex = (int)TerritoryRecordSet.Fields.Item("lindex").Value,
                    Parent = (int)TerritoryRecordSet.Fields.Item("Parent").Value,
                    Inactive = TerritoryRecordSet.Fields.Item("Inactive").Value.ToString(),
                };
                return Territory;
            }
            return null;
        }
        /// <summary>
        /// Returns Collection Of Territories 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Territory> GetTerritories()
        {
            List<Territory> territories = new List<Territory>();
            Recordset TerritoryRecordSet = (Recordset)_company.GetBusinessObject(BoObjectTypes.BoRecordset);
            TerritoryRecordSet.DoQuery($@"SELECT * FROM OTER");
            while (!TerritoryRecordSet.EoF)
            {
                Territory Territory = new Territory
                {
                    Description = TerritoryRecordSet.Fields.Item("descript").Value.ToString(),
                    TerritoryId = (int)TerritoryRecordSet.Fields.Item("territryID").Value,
                    Lindex = (int)TerritoryRecordSet.Fields.Item("lindex").Value,
                    Parent = (int)TerritoryRecordSet.Fields.Item("Parent").Value,
                    Inactive = TerritoryRecordSet.Fields.Item("Inactive").Value.ToString(),
                };
                territories.Add(Territory);
                TerritoryRecordSet.MoveNext();
            }
            return territories;
        }
    }
}