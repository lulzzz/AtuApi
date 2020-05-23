using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Models
{
    public class PermissionRoles
    {
        public int RoleId { get; set; }
        public virtual Role Roles { get; set; }

        public int PermissionId { get; set; }
        public virtual Permission Permissions { get; set; }
    }
}
