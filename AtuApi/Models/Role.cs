using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<PermissionRoles> PermissionRoles { get; set; }
    }
}
