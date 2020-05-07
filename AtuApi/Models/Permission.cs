using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string PermissionName { get; set; }

        public virtual ICollection<PermissionRoles> PermissionRoles { get; set; }
    }
}
