using AtuApi.Interfaces;
using DataContextHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _dataContext;
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            RoleRepository = new RoleRepository(_dataContext);
            BranchesRepository = new BranchRepositry(_dataContext);
            UserRepository = new UserRepository(_dataContext);
            PermissionRepository = new PermissionRepository(_dataContext);
        }
        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }
        public IRoleRepository RoleRepository { get; }
        public IBranchRepository BranchesRepository { get; }
        public IUserRepository UserRepository { get; }
        public IPermissionRepository PermissionRepository { get; }
    }
}
