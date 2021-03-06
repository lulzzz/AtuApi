﻿using AtuApi.Interfaces;
using DataContextHelper;
using DataModels.Iterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _dataContext;
        public UnitOfWork(DataContext dataContext, IDiManager diManager)
        {
            _dataContext = dataContext;
            RoleRepository = new RoleRepository(_dataContext);
            BranchesRepository = new BranchRepositry(_dataContext);
            UserRepository = new UserRepository(_dataContext);
            PermissionRepository = new PermissionRepository(_dataContext);
            ItemRepository = new ItemRepository(_dataContext, diManager);
            BusinessPartnerRepository = new BusinessPartnerRepository(_dataContext, diManager);
            EmployeeRepository = new EmployeeRepository(_dataContext, diManager);
            ApprovalTemplateRepository = new ApprovalTemplateRepository(_dataContext);
            PurchaseRequestRepository = new PurchaseRequestRepository(_dataContext);
            TerritoryRepository = new TerritoryRepository(_dataContext, diManager);
            ProjectRepository = new ProjectRepository(_dataContext, diManager);
            WareHouseRepository = new WareHouseRepository(_dataContext, diManager);
            ItemsWarehousesRepository = new ItemsWarehouseRepository(_dataContext, diManager);
            UnitOfMeasueGroupRepository = new UnitOfMeasueGroupsRepository(_dataContext, diManager);
            UnitOfMeasueRepository = new UnitOfMeasueRepository(_dataContext, diManager);
            NotificationHistoryRepository = new NotificationHistoryRepository(_dataContext);

        }
        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }
        public IRoleRepository RoleRepository { get; }
        public IBranchRepository BranchesRepository { get; }
        public IUserRepository UserRepository { get; }
        public IPermissionRepository PermissionRepository { get; }
        public IItemRepository ItemRepository { get; }
        public IBusinessPartnerRepository BusinessPartnerRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }
        public IApprovalTemplateRepository ApprovalTemplateRepository { get; }
        public IPurchaseRequestRepository PurchaseRequestRepository { get; }
        public ITerritoryRepository TerritoryRepository { get; }
        public IProjectRepository ProjectRepository { get; }
        public IItemsWarehousesRepository ItemsWarehousesRepository { get; }
        public IWareHouseRepository WareHouseRepository { get; }
        public IUnitOfMeasueGroupRepository UnitOfMeasueGroupRepository { get; }
        public IUnitOfMeasueRepository UnitOfMeasueRepository { get; }
        public INotificationHistoryRepository NotificationHistoryRepository { get; }


    }
}
