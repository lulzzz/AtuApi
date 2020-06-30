using AtuApi.Interfaces;
using AtuApi.Models;
using DataContextHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xaml.Permissions;

namespace AtuApi.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext context) : base(context)
        {

        }

        public new IEnumerable<Role> GetAll()
        {
            return RoleContext.Roles.Include(x => x.PermissionRoles).ThenInclude(p => p.Permissions).ToList();
        }
        public new Role Get(int id)
        {
            return RoleContext.Roles.Include(x => x.PermissionRoles).ThenInclude(p=>p.Permissions).FirstOrDefault(y=>y.Id == id);
        }
        private DataContext RoleContext => Context as DataContext;
    }
}
