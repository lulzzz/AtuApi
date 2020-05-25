using AtuApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        IBranchRepository BranchesRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        IItemRepository ItemRepository { get; }
        IBusinessPartnerRepository BusinessPartnerRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }

    }
}
