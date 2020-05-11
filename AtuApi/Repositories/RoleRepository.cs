using AtuApi.Interfaces;
using AtuApi.Models;
using DataContextHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext context) : base(context)
        {

        }
        private DataContext RoleContext => Context as DataContext;
    }
}
