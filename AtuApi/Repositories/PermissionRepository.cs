using AtuApi.Interfaces;
using AtuApi.Models;
using DataContextHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(DataContext context) : base(context)
        {

        }

        private DataContext PermissionsContext => Context as DataContext;



    }
}
